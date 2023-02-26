SELECT
	concat(c.FirstName,' ',c.LastName) as FullName,
	c.age,
	o.OrderID,
	o.DateCreated,
	o.MethodofPurchase as "Method of Purchase",
	od.ProductNumber,
	od.ProductOrigin
FROM Customer as c
inner join Orders as o on c.PersonID = o.PersonID
inner join OrderDetails as od on o.OrderID = od.OrderID
WHERE 
	od.ProductID = 1112222333