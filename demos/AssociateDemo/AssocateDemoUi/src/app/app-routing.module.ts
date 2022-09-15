import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssociateListComponent } from './components/associate-list/associate-list.component';
import { HomeComponent } from './components/home/home.component';
import { UserComponent } from './components/user/user.component';
import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'associates', component: AssociateListComponent, canActivate: [AuthGuard]},
  {path: 'user', component: UserComponent, canActivate: [AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
