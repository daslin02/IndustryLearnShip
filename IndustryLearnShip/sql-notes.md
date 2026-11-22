# SQL notes
> Учебная БД: PracticeDB. Скрипт создания — `init.sql`.
> Все запросы выполнялись в SSMS.


## Task 01 — Создание базы и таблиц
### SQL

### Запрос
```sql
USE PracticeDB;
GO
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE';
```
### Результат

![](./DataBase/level-1/Picture/Task01.png)

### Вывод

не чего сложного не было с этим уже приходилось работать

## Task 02 — INSERT: заполнение данными
### SQL

### Запрос
```sql
SELECT 'Departments' AS Table_Name, COUNT(*) AS Row_Count FROM Departments
UNION ALL
SELECT 'Employees', COUNT(*) FROM Employees
UNION ALL
SELECT 'Projects', COUNT(*) FROM Projects
UNION ALL
SELECT 'EmployeeProjects', COUNT(*) FROM EmployeeProjects;
```
### Результат

![](./DataBase/level-1/Picture/Task02.png)

### Вывод

не чего сложного не было с этим уже приходилось работать

## Task 03 — SELECT + WHERE: базовые выборки
### SQL

### Запрос
```sql
-- 1. Сотрудники с зарплатой > 50000
SELECT * FROM Employees WHERE Salary > 50000;

-- 2. Сотрудники, нанятые в 2023 году
SELECT * FROM Employees WHERE YEAR(HireDate) = 2023;

-- 3. Сотрудники, чьё имя начинается на «А»
SELECT * FROM Employees WHERE EmployeeName LIKE N'А%';

-- 4. Сотрудники из отдела DepartmentId = 2
SELECT * FROM Employees WHERE DepartmentId = 2;

-- 5. Сотрудники с зарплатой 40000–60000
SELECT * FROM Employees WHERE Salary BETWEEN 40000 AND 60000;
```
### Результат

![](./DataBase/level-1/Picture/Task03.png)

### Вывод

Всё понятно



## Task 04 — ORDER BY + TOP: сортировка и лимит
### SQL

### Запрос
```sql
-- Топ-3 по зарплате (убывание)
SELECT TOP 3 * FROM Employees ORDER BY Salary DESC;

-- Топ-5 самых давних сотрудников (возрастание HireDate)
SELECT TOP 5 * FROM Employees ORDER BY HireDate ASC;

-- Сортировка по отделу (возр.), затем по зарплате (убыв.)
SELECT * FROM Employees 
ORDER BY DepartmentId ASC, Salary DESC;
```
### Результат

![](./DataBase/level-1/Picture/Task04.png)

### Вывод
Оператор `TOP` удобно использовать для быстрого анализа лидеров или "старичков" компании. Важно помнить, что при сортировке по нескольким полям порядок указания столбцов в `ORDER BY` критически влияет на результат.
## Task 05 — Агрегация: COUNT, SUM, AVG, MIN, MAX
### SQL

### Запрос
```sql
SELECT 
    COUNT(*) AS TotalEmployees,
    SUM(Salary) AS TotalSalary,
    ROUND(AVG(Salary), 2) AS AvgSalary,
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary,
    COUNT(CASE WHEN Salary > 50000 THEN 1 END) AS HighSalaryCount
FROM Employees;
```
### Результат

![](./DataBase/level-1/Picture/Task05.png)

### Вывод
Агрегатные функции позволяют получить сводную статистику одним запросом. Функция `ROUND` необходима для корректного отображения средней зарплаты, так как `AVG` часто возвращает длинную дробную часть. Условный `COUNT` через `CASE` полезен для подсчета специфических групп без дополнительных фильтров.

## Task 06 — GROUP BY: статистика по отделам
### SQL

### Запрос
```sql
SELECT 
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    ROUND(AVG(Salary), 2) AS AvgSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AvgSalary DESC;
```
### Результат

![](./DataBase/level-1/Picture/Task06.png)

### Вывод
`GROUP BY` преобразует детальные данные в сводные строки. Главное правило: все столбцы в `SELECT`, не являющиеся агрегатными функциями, должны быть перечислены в `GROUP BY`. Иначе сервер не поймет, какое значение выводить для группы.

## Task 07 — GROUP BY + HAVING: фильтрация групп
### SQL

### Запрос
```sql
-- Отделы с > 2 сотрудниками
SELECT DepartmentId, COUNT(*) AS EmpCount 
FROM Employees 
GROUP BY DepartmentId 
HAVING COUNT(*) > 2;

-- Отделы со средней зарплатой > 55000
SELECT DepartmentId, ROUND(AVG(Salary), 2) AS AvgSal 
FROM Employees 
GROUP BY DepartmentId 
HAVING AVG(Salary) > 55000;

-- Отделы с суммарной зарплатой > 150000
SELECT DepartmentId, SUM(Salary) AS TotalSal 
FROM Employees 
GROUP BY DepartmentId 
HAVING SUM(Salary) > 150000;
```
### Результат

![](./DataBase/level-1/Picture/Task07.png)

### Вывод
Ключевое отличие `HAVING` от `WHERE`: `WHERE` фильтрует отдельные строки *до* группировки, а `HAVING` фильтрует уже сформированные группы *после* агрегации. Попытка использовать `WHERE` с агрегатной функцией вызовет ошибку синтаксиса.

## Task 08 — INNER JOIN: сотрудники и отделы
### SQL

### Запрос
```sql
SELECT 
    e.EmployeeName,
    d.DepartmentName,
    e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;
```
### Результат

![](./DataBase/level-1/Picture/Task08.png)

### Вывод
`INNER JOIN` возвращает только те строки, для которых нашлось совпадение в обеих таблицах. Это базовый способ нормализации данных: мы храним ID отдела в таблице сотрудников, но для отчета подставляем текстовое название из справочника отделов.


## Task 09 — LEFT JOIN: сотрудники без проектов
### SQL

### Запрос
```sql
SELECT 
    e.EmployeeId,
    e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL;
```
### Результат

![](./DataBase/level-1/Picture/Task09.png)

### Вывод
`LEFT JOIN` сохраняет все строки из левой таблицы (`Employees`), даже если справа нет совпадений. В таких случаях столбцы правой таблицы заполняются `NULL`. Фильтрация по `IS NULL` — стандартный паттерн поиска "несуществующих связей" (анти-соединение).


## Task 10 — Множественный JOIN: полная картина
### SQL

### Запрос
```sql
SELECT 
    e.EmployeeName,
    d.DepartmentName,
    p.ProjectName,
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName;
```
### Результат

![](./DataBase/level-1/Picture/Task10.png)

### Вывод
При соединении 4 таблиц важно выстраивать цепочку связей логично: Сотрудники → Отделы (через DeptId), Сотрудники → Назначения (через EmpId), Назначения → Проекты (через ProjId). Псевдонимы таблиц (`e`, `d`, `p`, `ep`) делают запрос читаемым и сокращают код.

## Task 11 — Self-join: иерархия руководителей
### SQL

### Запрос
```sql
SELECT 
    e.EmployeeName,
    m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId;
```
### Результат

![](./DataBase/level-2/Picture/Task11.png)

### Вывод
Self-join позволяет соединить таблицу саму с собой для работы с иерархическими данными. Использование `LEFT JOIN` критически важно: оно сохраняет сотрудников, у которых нет руководителя (`ManagerId IS NULL`), показывая для них `NULL` в столбце `ManagerName`. При `INNER JOIN` такие сотрудники пропали бы из выборки.

## Task 12 — Подзапросы в WHERE
### SQL

### Запрос
```sql
-- Сотрудники с зарплатой выше средней по компании
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- Сотрудники с максимальной зарплатой
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
```
### Результат

![](./DataBase/level-2/Picture/Task12.png)

### Вывод
Скалярный подзапрос в `WHERE` должен возвращать ровно одно значение. Если подзапрос вернет несколько строк, выполнение завершится ошибкой. Для сравнения с набором значений нужно использовать операторы `IN`, `ANY` или `ALL`. В данном случае `AVG()` и `MAX()` гарантированно дают один результат.

## Task 13 — Скалярные подзапросы в SELECT
### SQL

### Запрос
```sql
SELECT 
    EmployeeName,
    Salary,
    DepartmentId,
    ROUND(
        Salary - (
            SELECT AVG(e2.Salary) 
            FROM Employees e2 
            WHERE e2.DepartmentId = e.DepartmentId
        ), 2
    ) AS DiffFromDeptAvg
FROM Employees e;
```
### Результат

![](./DataBase/level-2/Picture/Task13.png)

### Вывод
Коррелированный подзапрос в `SELECT` выполняется для каждой строки внешнего запроса. Ссылка на внешний псевдоним `e.DepartmentId` внутри подзапроса связывает их. На больших таблицах такой подход может быть медленным из-за многократного выполнения подзапроса; в таких случаях эффективнее использовать `JOIN` с агрегированной производной таблицей или оконные функции.
# Task 14 — EXISTS / NOT EXISTS
### SQL

### Запрос
```sql
-- Сотрудники, у которых есть хотя бы один проект
SELECT EmployeeId, EmployeeName
FROM Employees e
WHERE EXISTS (
    SELECT 1 
    FROM EmployeeProjects ep 
    WHERE ep.EmployeeId = e.EmployeeId
);

-- Сотрудники без проектов
SELECT EmployeeId, EmployeeName
FROM Employees e
WHERE NOT EXISTS (
    SELECT 1 
    FROM EmployeeProjects ep 
    WHERE ep.EmployeeId = e.EmployeeId
);
```
### Результат

![](./DataBase/level-2/Picture/Task14.png)

### Вывод
`EXISTS` проверяет наличие строк в подзапросе и останавливает сканирование при первом совпадении, что делает его эффективным для больших наборов данных. В отличие от `IN`, `EXISTS` корректно работает с `NULL` значениями. Результаты этих запросов должны полностью совпадать с результатами заданий 8 и 9, где использовались `JOIN`.
## Task 15 — UNION / UNION ALL
### SQL

### Запрос
```sql
-- UNION: уникальные строки
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE Salary > 60000
UNION
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE YEAR(HireDate) < 2022;

-- UNION ALL: все строки включая дубликаты
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE Salary > 60000
UNION ALL
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE YEAR(HireDate) < 2022;
```
### Результат

![](./DataBase/level-2/Picture/Task15.png)

### Вывод
`UNION` автоматически удаляет дубликаты, выполняя дополнительную сортировку и сравнение, что требует ресурсов. `UNION ALL` просто объединяет результаты без проверки уникальности и работает значительно быстрее. Разница в количестве строк между двумя запросами показывает число сотрудников, которые одновременно имеют зарплату > 60000 И наняты до 2022 года.
## Task 16 — UPDATE: изменение данных
### SQL

### Запрос
```sql
-- Проверка ДО обновления
SELECT EmployeeId, EmployeeName, Salary, DepartmentId, HireDate 
FROM Employees WHERE DepartmentId = 1 OR YEAR(HireDate) < 2022;

-- Увеличение зарплаты на 10% для отдела 1
UPDATE Employees SET Salary = Salary * 1.10 WHERE DepartmentId = 1;

-- Увеличение зарплаты на 5000 для нанятых до 2022
UPDATE Employees SET Salary = Salary + 5000 WHERE YEAR(HireDate) < 2022;

-- Обновление даты найма одного сотрудника
UPDATE Employees SET HireDate = '2023-01-01' WHERE EmployeeId = 4;

-- Проверка ПОСЛЕ обновления
SELECT EmployeeId, EmployeeName, Salary, DepartmentId, HireDate 
FROM Employees WHERE DepartmentId = 1 OR YEAR(HireDate) < 2022 OR EmployeeId = 4;
```
### Результат

![](./DataBase/level-2/Picture/Task16.png)

### Вывод
Перед любым `UPDATE` необходимо выполнять `SELECT` с тем же условием `WHERE`, чтобы убедиться, что затронуты только целевые строки. Отсутствие `WHERE` в `UPDATE` изменит ВСЕ строки таблицы — это одна из самых опасных ошибок. После изменения данных обязателен контрольный `SELECT` для подтверждения корректности.

## Task 17 — DELETE: удаление данных
### SQL

### Запрос
```sql
-- Удаление назначений с Hours = 0
DELETE FROM EmployeeProjects WHERE Hours = 0;
SELECT COUNT(*) AS RemainingAssignments FROM EmployeeProjects;

-- Удаление сотрудника (сначала убираем назначения из-за FK)
DELETE FROM EmployeeProjects WHERE EmployeeId = 8;
DELETE FROM Employees WHERE EmployeeId = 8;
SELECT COUNT(*) AS RemainingEmployees FROM Employees;
```
### Результат

![](./DataBase/level-2/Picture/Task17.png)

### Вывод
При удалении записей из родительской таблицы (`Employees`) сначала необходимо удалить зависимые записи в дочерних таблицах (`EmployeeProjects`), иначе нарушение внешнего ключа вызовет ошибку. Альтернатива — настроить каскадное удаление (`ON DELETE CASCADE`) при создании FK. Всегда проверяйте `COUNT(*)` после `DELETE` для контроля количества удаленных строк.
## Task 18 — Транзакции: BEGIN TRAN / COMMIT / ROLLBACK
### SQL

### Запрос
```sql
-- Демонстрация ROLLBACK
BEGIN TRANSACTION;
UPDATE Employees SET Salary = 999999 WHERE EmployeeId = 1;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;
ROLLBACK;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;

-- Демонстрация COMMIT
BEGIN TRANSACTION;
UPDATE Employees SET Salary = 70000 WHERE EmployeeId = 1;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;
COMMIT;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;
```
### Результат

![](./DataBase/level-2/Picture/Task18.png)

### Вывод
Транзакция обеспечивает атомарность: либо все изменения сохраняются (`COMMIT`), либо ни одно (`ROLLBACK`). Внутри активной транзакции видны незафиксированные изменения только текущему соединению. `ROLLBACK` возвращает данные к состоянию на момент `BEGIN TRANSACTION`. Это фундаментальный механизм защиты целостности данных при сложных операциях.

## Task 19 — Представления (VIEW)
### SQL

### Запрос
```sql
CREATE VIEW vw_EmployeeDetails AS
SELECT 
    e.EmployeeName,
    d.DepartmentName,
    p.ProjectName,
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId;
GO

-- 2. Использование представления
SELECT * FROM vw_EmployeeDetails ORDER BY DepartmentName, EmployeeName;
GO

-- 3. Удаление представления
DROP VIEW IF EXISTS vw_EmployeeDetails;
GO
```
### Результат

![](./DataBase/level-2/Picture/Task19.png)

### Вывод
Представление (`VIEW`) — это сохраненный запрос, который выступает как виртуальная таблица. Оно не хранит данные физически, а выполняет underlying-запрос при каждом обращении. Преимущества: упрощение сложных запросов, централизация бизнес-логики, ограничение доступа к отдельным столбцам. Представление можно удалять и пересоздавать без потери исходных данных.



## Task 20 — Индексы: создание и анализ
### SQL

### Запрос
```sql
-- Включение статистики IO
SET STATISTICS IO ON;

-- Запрос ДО создания индексов
SELECT * FROM Employees WHERE DepartmentId = 1 AND Salary > 50000;

-- Создание индексов
CREATE INDEX IX_Employees_DepartmentId ON Employees(DepartmentId);
CREATE INDEX IX_Employees_Salary ON Employees(Salary);

-- Запрос ПОСЛЕ создания индексов
SELECT * FROM Employees WHERE DepartmentId = 1 AND Salary > 50000;

-- Отключение статистики
SET STATISTICS IO OFF;
```
### Результат

![](./DataBase/level-2/Picture/Task20.png)

### Вывод
Индексы ускоряют поиск ценой замедления операций записи (`INSERT/UPDATE/DELETE`) и расхода дискового пространства. `SET STATISTICS IO ON` показывает количество логических чтений страниц: чем меньше значение, тем эффективнее запрос. Составной индекс `(DepartmentId, Salary)` был бы еще эффективнее для данного запроса, так как покрывает оба условия фильтрации одним поиском.
## Task 21 — Хранимые процедуры
### SQL

### Запрос
```sql
USE PracticeDB;
GO
-- Процедура: сотрудники по отделу (CREATE PROCEDURE — первый оператор пакета, нужен GO)
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DeptId INT
AS
BEGIN
    SELECT EmployeeName, Salary, HireDate
    FROM Employees
    WHERE DepartmentId = @DeptId;
END;
GO

EXEC sp_GetEmployeesByDepartment @DeptId = 1;
GO

-- Процедура с OUTPUT-параметром: средняя зарплата отдела
CREATE PROCEDURE sp_GetAvgSalaryByDept
    @DeptId INT,
    @AvgSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @AvgSalary = AVG(Salary)
    FROM Employees
    WHERE DepartmentId = @DeptId;
END;
GO

DECLARE @Result DECIMAL(10,2);
EXEC sp_GetAvgSalaryByDept @DeptId = 1, @AvgSalary = @Result OUTPUT;
SELECT @Result AS AvgSalary;
GO

-- Очистка
DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
DROP PROCEDURE IF EXISTS sp_GetAvgSalaryByDept;
GO
```
### Результат

![](./DataBase/level-3/Picture/Task21.png)

### Вывод
Хранимые процедуры инкапсулируют логику на стороне сервера. Параметры защищают от SQL-инъекций и делают код переиспользуемым. `OUTPUT`-параметр удобен для возврата единичного значения без результирующего набора. Как и `CREATE VIEW`, `CREATE PROCEDURE` должен быть первым оператором пакета — нужен `GO`.
