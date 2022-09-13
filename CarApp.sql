USE [Practice]
GO
/****** Object:  StoredProcedure [dbo].[sp_EmployeeDept]    Script Date: 9/13/2022 5:49:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_EmployeeDept]
as
begin
select p.EId,p.E_Name,p.Location,p.Salary,c.Dept_Name from Employees as p inner join  Department as c on p.EID=c.EId

end


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_Productdetails]
as 
begin
select PId,P_Name,Quantity,size,cost from Product
end
GO

