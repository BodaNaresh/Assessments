import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { ShowComponent } from './show/show.component';


const routes:Routes=
[{   path: '',   pathMatch: 'prefix',component:ShowComponent }
, {   path: 'employee',   component: EmployeeComponent }]

// [
//   {path:'employee',component:EmployeeComponent},
  
// ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

