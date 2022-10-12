import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { EmployeeModel } from '../employee-model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  dataSaved=false;
  employeeForm:null | string |any ;
  allEmployees?:Observable<EmployeeModel[]>;
  employeeIdUpdate:any;
  message=null;
  constructor(private formbuilder:FormBuilder,private service:EmployeeService) { }
  
  ngOnInit() {
 this.employeeForm = this.formbuilder.group({
  EmpId:['',[Validators.required]],
  EmpName:['',[Validators.required]],
  DateOfBirth:['',[Validators.required]],
  Gender:['',[Validators.required]],
  EmailId:['',[Validators.required]],
  Address:['',[Validators.required]],
  Pincode:['',[Validators.required]]
 })
this.loadAllEmp()
  }
  loadAllEmp(){
    this.allEmployees = this.service.getAllEmployee();
  }
  onFormSubmit(){
    this.dataSaved = false;
    const employee = this.employeeForm.value;
    this.CreateEmployee(employee);
    this.employeeForm.reset();
  }
   updateEmp(employeeId:any){
    this.service.getEmployeeById(employeeId).subscribe(emp=>{
    this.dataSaved = false;
    this.employeeIdUpdate=emp.EmpId;
    this.employeeForm.controls['EmpName'].setValue(emp.EmpName);
    this.employeeForm.controls['DateOfBirth'].setValue(emp.DateOfBirth);
    this.employeeForm.controls['EmailId'].setValue(emp.EmailId);
    this.employeeForm.controls['Gender'].setValue(emp.Gender);
    this.employeeForm.controls['Address'].setValue(emp.Address);
    this.employeeForm.controls['Pincode'].setValue(emp.Pincode);

    });
  }

    CreateEmployee(employee:EmployeeModel){
      if(this.employeeIdUpdate == null){
         this.service.createEmployee(employee).subscribe(()=>{
          this.dataSaved=true;
          this.loadAllEmp();
          this.employeeIdUpdate=null;
         
         }
         );
      }
        else{
           employee.EmpId = this.employeeIdUpdate;
           this.service.updateEmployee(employee).subscribe(()=>{
            this.dataSaved=true;
            this.loadAllEmp();
            this.employeeIdUpdate=null;
            this.employeeForm.reset();
           })
        }
      
     }
     deleteEmp(employeeId:string){
      if(confirm("Are you sure want to delete this?")){
        this.service.deleteEmployeeById(employeeId).subscribe(()=>{
          this.dataSaved=true;
          this.loadAllEmp();
          this.employeeIdUpdate=null;
          this.employeeForm.reset();
        })
      }
     }
     resetForm(){
      this.employeeForm.reset();
      this.dataSaved = false;
     }
}
