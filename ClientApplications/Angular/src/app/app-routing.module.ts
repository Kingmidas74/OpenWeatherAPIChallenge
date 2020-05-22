import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { WorkspaceLayoutComponent } from './workspace/components/workspace-layout/workspace-layout.component';
import { WorkspaceModule } from './workspace/workspace.module';



export const routes: Routes = [  
  {
    path: '',
    redirectTo: 'workspace',
    pathMatch: 'full',
  },
  {
    path: 'workspace',
    component: WorkspaceLayoutComponent,
    children: [{
      path: '',      
      loadChildren: './workspace/workspace.module#WorkspaceModule',
    }]
  },
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    WorkspaceModule,
    RouterModule.forRoot(routes, {
       useHash: true
    })
  ],
  exports: [
  ]
})
export class AppRoutingModule { }
