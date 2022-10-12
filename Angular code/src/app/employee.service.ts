import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeModel } from './employee-model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
url='https://localhost:44304/Api/Employee/'
  constructor(private http:HttpClient) { }
  getAllEmployee():Observable<EmployeeModel[]>{
    return this.http.get<EmployeeModel[]>(this.url+'AllEmployeeDetails');
  }
  getEmployeeById(employeeId:number):Observable<EmployeeModel>{
    return this.http.get<EmployeeModel>(this.url+'GetEmployeeDetailsById/{employeeId})?employeeId='+employeeId);
  }
  createEmployee(employee:EmployeeModel):Observable<EmployeeModel>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})}
    return this.http.post<EmployeeModel>(this.url+'InsertEmployeeDetails',employee,httpOptions);
  }
  updateEmployee(employee:EmployeeModel):Observable<EmployeeModel>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.put<EmployeeModel>(this.url+'UpdateEmployeeDetails/',employee,httpOptions);
  }
  deleteEmployeeById(employeeId:string):Observable<number>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})}
    return this.http.delete<number>(this.url+'/DeleteOfEmployee?id='+employeeId,httpOptions);
  }

}
