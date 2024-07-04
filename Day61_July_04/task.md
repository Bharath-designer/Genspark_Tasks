# Working with postgres with docker

<br/>

### Pulling postgres image from docker hub
```bash
docker pull postgres
```

<br/>

### Starting a postgres docker container
```bash
docker run --name postgres-container -e POSTGRES_PASSWORD=mysecretpassword -d -p 5432:5432 postgres
```

<br/>

### Connecting to the PostgreSQL database within the Docker container using psql:
```bash
docker exec -it postgres-container psql -U postgres
```

<br/>

### Executing SQL commands to create database ```dbdocker``` and creating tables Employee, Department, Salary and establishing relationships.
```sql
CREATE DATABASE dbdocker;

-- Connect to the new database
\c dbdocker;

CREATE TABLE Department (
    department_id SERIAL PRIMARY KEY,
    department_name VARCHAR(100) NOT NULL
);

CREATE TABLE Employee (
    employee_id SERIAL PRIMARY KEY,
    employee_name VARCHAR(100) NOT NULL,
    age INTEGER,
    phone VARCHAR(20),
    department_id INTEGER REFERENCES Department(department_id)
);

CREATE TABLE Salary (
    salary_id SERIAL PRIMARY KEY,
    employee_id INTEGER REFERENCES Employee(employee_id),
    salary DECIMAL(10, 2)
);
```

<br/>

### Inserting data into the tables

```sql
INSERT INTO Department (department_name) VALUES
    ('IT'),
    ('HR'),
    ('Finance');

INSERT INTO Employee (employee_name, age, phone, department_id) VALUES
    ('John Doe', 30, '123-456-7890', 1),  
    ('Jane Smith', 28, '987-654-3210', 2),  
    ('Michael Johnson', 35, '111-222-3333', 3);  

INSERT INTO Salary (employee_id, salary) VALUES
    (1, 60000.00),
    (2, 55000.00),
    (3, 70000.00);

```

<br/>

### Log off the instance
```bash
docker stop postgres-container
```
<br/>

### Restarting the instance
```bash
docker start postgres-container
```

<br/>

### Executing Select query
```sql
SELECT e.employee_name, e.age, e.phone, d.department_name, s.salary
 FROM Employee e
 JOIN Department d ON e.department_id = d.department_id
 JOIN Salary s ON e.employee_id = s.employee_id
```