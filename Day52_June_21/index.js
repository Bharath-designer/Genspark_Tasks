class Person {
    constructor(name, age) {
        this._name = name;
        this._age = age;
    }

    getName() {
        return this._name;
    }

    setName(name) {
        this._name = name;
    }

    getAge() {
        return this._age;
    }

    setAge(age) {
        this._age = age;
    }

    displayInfo() {
        console.log(`Name: ${this._name}, Age: ${this._age}`);
    }
}

class Student extends Person {
    constructor(name, age, studentId, major) {
        super(name, age);
        this._studentId = studentId;
        this._major = major;
    }

    getStudentId() {
        return this._studentId;
    }

    setStudentId(studentId) {
        this._studentId = studentId;
    }

    getMajor() {
        return this._major;
    }

    setMajor(major) {
        this._major = major;
    }

    displayInfo() {
        super.displayInfo();
        console.log(`Student ID: ${this._studentId}, Major: ${this._major}`);
    }
}

const student = new Student("Alice", 20, "S123456", "Computer Science");

console.log(student.getName());
student.setAge(21);
student.displayInfo();
