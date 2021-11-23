import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  flag = true;
  constructor(public authService : AuthService,
    public router : Router,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  showMenu(){
    if(this.router.url !== '/user/login')
      return true
    return false
  }

  logout(){
    localStorage.removeItem('token');
    this.toastr.show("Logout realizado");
    this.router.navigate(['/user/login']);
  }

  entrar(){
    this.router.navigate(['/user/login'])
  }

  userName(){
    return sessionStorage.getItem("username")
  }

}
