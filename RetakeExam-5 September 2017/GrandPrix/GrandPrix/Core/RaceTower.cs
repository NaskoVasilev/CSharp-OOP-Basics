using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int lapsNumber;
    private int trackLength;
    List<Driver> racingDrivers;
    Stack<Driver> crashedDrivers;
    TyreFactory tyreFactory;
    DriverFactory driverFactory;
    private int currentLapNumber;
    private Weather currentWeather;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.currentWeather = Weather.Sunny;
        this.crashedDrivers = new Stack<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string type = commandArgs[0];
            string name = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            double tyreHardness = double.Parse(commandArgs[5]);
            double grip = 0;

            if (commandArgs.Count > 6)
            {
                grip = double.Parse(commandArgs[6]);
            }

            Tyre tyre = tyreFactory.CreateTyre(tyreType, tyreHardness, grip);
            Car car = new Car(hp, fuelAmount, tyre);
            Driver driver = driverFactory.CreateDriver(type, name, car);

            racingDrivers.Add(driver);
        }
        catch { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string driverName = commandArgs[1];
        Driver driver = GetDriver(driverName);
        driver.GoToBox(commandArgs);
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();
        int numberOfLaps = int.Parse(commandArgs[0]);
        string output = "";

        if (numberOfLaps > this.lapsNumber - this.currentLapNumber)
        {
            return $"There is no time! On lap {currentLapNumber}.";
        }

        for (int i = 0; i < numberOfLaps; i++)
        {
            if (RaceOver())
            {
                break;
            }

            for (int j = 0; j < racingDrivers.Count; j++)
            {
                try
                {
                    racingDrivers[j].IncreaseTotalTime(this.trackLength);
                    racingDrivers[j].Car.ReduceFuelAmount(this.trackLength, racingDrivers[j].FuelConsumptionPerKm);
                    racingDrivers[j].Car.Tyre.ReduceDegradation();
                }
                catch (ArgumentException ex)
                {
                    Driver driver = racingDrivers[j];
                    this.Fail(driver, ex.Message);
                    //Because in FailMethod remove a driver from racingDriver collection
                    j--;
                }
            }

            this.currentLapNumber++;
            output = Overtake();

            if (!string.IsNullOrEmpty(output))
            {
                sb.AppendLine(output);
            }
        }

        return sb.ToString().TrimEnd();
    }

    public bool RaceOver()
    {
        return this.currentLapNumber == this.lapsNumber;
    }

    public string GetWinner()
    {
        Driver winner = racingDrivers.OrderBy(x => x.TotalTime).First();

        return $"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.";
    }

    private string Overtake()
    {
        StringBuilder sb = new StringBuilder();
        List<Driver> sortedDrivers = racingDrivers
                        .OrderByDescending(x => x.TotalTime)
                        .ToList();

        for (int j = 0; j < sortedDrivers.Count - 1; j++)
        {
            Driver currentDriver = sortedDrivers[j];
            Driver nextDriver = sortedDrivers[j + 1];
            bool success = false;
            int overTakeInterval = 2;
            double timeDifference = currentDriver.TotalTime - nextDriver.TotalTime;

            bool isAgressiveDriver = currentDriver is AggressiveDriver && currentDriver.Car.Tyre is UltrasoftTyre;
            bool isEndureDriver = currentDriver is EnduranceDriver && currentDriver.Car.Tyre is HardTyre;
            bool crash = (isAgressiveDriver && this.currentWeather == Weather.Foggy)
                || (isEndureDriver && this.currentWeather == Weather.Rainy);

            if ((isAgressiveDriver || isEndureDriver) && timeDifference <= 3)
            {
                if (crash)
                {
                    Fail(currentDriver, ErrorMessages.Crashed);
                    continue;
                }

                success = true;
                overTakeInterval = 3;
            }
            else if (timeDifference <= 2)
            {
                success = true;
            }

            if (success)
            {
                currentDriver.TotalTime -= overTakeInterval;
                nextDriver.TotalTime += overTakeInterval;
                j++;
                sb.AppendLine($"{currentDriver.Name} has overtaken {nextDriver.Name} on lap {currentLapNumber}.");
            }
        }

        return sb.ToString().TrimEnd();
    }

    private void Fail(Driver driver, string failureReason)
    {
        this.racingDrivers.Remove(driver);
        driver.FailureReason = failureReason;
        driver.IsRacing = false;
        crashedDrivers.Push(driver);
    }

    public string GetLeaderboard()
    {
        int position = 1;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {currentLapNumber}/{this.lapsNumber}");

        List<Driver> drivers = this.racingDrivers.OrderBy(x => x.TotalTime)
            .Concat(this.crashedDrivers)
            .ToList();

        foreach (var driver in drivers)
        {
            sb.AppendLine($"{position++} {driver.Name} {driver.Status}");
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherAsString = commandArgs[0];

        Enum.TryParse(weatherAsString, out Weather weather);
        this.currentWeather = weather;
    }

    private Driver GetDriver(string driverName)
    {
        return racingDrivers.FirstOrDefault(x => x.Name == driverName);
    }
}
