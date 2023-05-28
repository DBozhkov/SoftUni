class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || salary < 0 || !salary|| !position || !department) {
            throw new Error("Invalid input!");
        }
        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push({ name, salary, position });

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }

    bestDepartment() {
        let bestAverageSalary = 0;
        let bestDepartment = '';
        let bestEmployees = [];
        for (const [key, value] of Object.entries(this.departments)) {
            let tempAverageSalary = 0;
            tempAverageSalary = value.reduce((acc, obj) => acc + obj.salary, 0);
            if (tempAverageSalary / value.length > bestAverageSalary) {
                bestAverageSalary = tempAverageSalary / value.length;
                bestDepartment = key;
                bestEmployees = value;
            }
        }
        bestEmployees.sort((a, b) => {
            return b.salary - a.salary || a.name.localeCompare(b.name)
        });

        let finalEmployees = '';
        for (const employee of bestEmployees) {
            finalEmployees += `${employee.name} ${employee.salary} ${employee.position}\n`
        }
        let clearedEmployees = finalEmployees.trim();
        return `Best Department is: ${bestDepartment}\nAverage salary: ${bestAverageSalary.toFixed(2)}\n${clearedEmployees}`;
    }
}
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
