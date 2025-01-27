/* User SP's ----------------------------------- */

Create Proc [dbo].[PR_LOC_User_SelectAll]
As
Begin
	Select * from LOC_User
End

Create Proc [dbo].[PR_LOC_Country_SelectAll]
As
Begin
	select * from LOC_Country
End

Create Proc [dbo].[PR_LOC_State_SelectAll]
As
Begin
	select * from LOC_State
End

Create Proc [dbo].[PR_LOC_District_SelectAll]
As
Begin
	select * from LOC_District
End

Create Proc [dbo].[PR_LOC_Taluka_SelectAll]
As
Begin
	select * from LOC_Taluka
End

Create Proc [dbo].[PR_LOC_City_SelectAll]
As
Begin
	Select * from LOC_City
End
