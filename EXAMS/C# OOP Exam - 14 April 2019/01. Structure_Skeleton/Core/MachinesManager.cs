namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;

        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            Pilot pilot = new Pilot(name);

            pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var machine = machines.Where(m => m.Name == name && m.GetType().Name == nameof(Tank)).FirstOrDefault();

            if (machine != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            Tank newMachine = new Tank(name, attackPoints, defensePoints);

            machines.Add(newMachine);

            return string.Format(OutputMessages.TankManufactured, name, newMachine.AttackPoints, newMachine.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var machine = machines.Where(f => f.Name == name && f.GetType().Name == nameof(Fighter))
                .FirstOrDefault();

            if (machine != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            Fighter newMachine = new Fighter(name, attackPoints, defensePoints);

            machines.Add(newMachine);

            return string.Format(OutputMessages.FighterManufactured, name, newMachine.AttackPoints, newMachine.DefensePoints, newMachine.AggressiveMode == true ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilots.Where(p => p.Name == selectedPilotName).FirstOrDefault();

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var machine = machines.Where(m => m.Name == selectedMachineName).FirstOrDefault();

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;

            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.Where(m => m.Name == attackingMachineName).FirstOrDefault();

            var defendingMachine = machines.Where(m => m.Name == defendingMachineName).FirstOrDefault();

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = pilots.Where(p => p.Name == pilotReporting).FirstOrDefault();

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = machines.Where(m => m.Name == machineName).FirstOrDefault();

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            Fighter fighter = (Fighter)machines
                .Where(m => m.Name == fighterName)
                .Where(m => m.GetType().Name == "Fighter")
                .FirstOrDefault();

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank tank = (Tank)machines
                .Where(m => m.Name == tankName)
                .Where(m => m.GetType().Name == "Tank")
                .FirstOrDefault();

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}