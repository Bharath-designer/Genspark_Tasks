let person = {
    name: 'John',
    age: 19,
    getDetails: function() {
        return `${this.name} is ${this.age} years old.`;
    }
};


let student = {
    subject: 'Engineering',
    getDetails: function() {
        return `${this.name} is ${this.age} years old and studies ${this.subject}.`;
    }
};

student.__proto__ = person;


console.log(student.getDetails()); 
console.log(student.name); 
console.log(student.age); 


let student2 = Object.create(student);
student2.name = 'Alice';
student2.age = 22;
student2.subject = 'Computer Science';

console.log(student2.getDetails()); 
console.log(student2.name); 
console.log(student2.age); 
