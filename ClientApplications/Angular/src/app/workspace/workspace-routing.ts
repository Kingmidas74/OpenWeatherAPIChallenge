import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';



export const WorkspaceRoutes: Routes = [
    { path: '',      component: DashboardComponent },
    { path: 'dashboard',      component: DashboardComponent }
];