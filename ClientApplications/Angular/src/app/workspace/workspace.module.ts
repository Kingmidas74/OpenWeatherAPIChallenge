import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../../environments/environment';

import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { WorkspaceRoutes } from './workspace-routing';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { WorkspaceLayoutComponent } from './components/workspace-layout/workspace-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    SidebarComponent, 
    NavbarComponent, 
    FooterComponent, 
    WorkspaceLayoutComponent, 
    DashboardComponent        
  ],
  imports: [
    CommonModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    RouterModule.forChild(WorkspaceRoutes),    
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    SidebarComponent,
    NavbarComponent,
    FooterComponent
  ]
})
export class WorkspaceModule { }
