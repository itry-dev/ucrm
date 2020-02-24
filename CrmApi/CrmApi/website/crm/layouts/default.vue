<template>
<div>
  <!-- <nav class="navbar navbar-dark bg-dark flex-md-nowrap p-0 shadow">
    <a class="navbar-brand col-sm-3 col-md-2 mr-0" href="#">Company name</a>
    <input class="form-control form-control-dark w-100" type="text" placeholder="Search" aria-label="Search">
    <ul class="navbar-nav px-3">
      <li class="nav-item text-nowrap">
        <a class="nav-link" href="#">Sign out</a>
      </li>
    </ul>
  </nav> -->
  <div class="container-fluid">
    <div class="row">
      <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
          <ul class="nav flex-column">
            <li class="nav-item">
              <nuxt-link to="/" class="nav-link active" href="#">
                <i class="material-icons pr-2">format_list_bulleted</i>
                  Dashboard <span class="sr-only">(current)</span>
              </nuxt-link>
            </li>
          </ul>
            <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
              <span>Customers</span>
            </h6>
            <ul class="nav flex-column">
              <li class="nav-item">
                <nuxt-link to="/customers" class="nav-link" href="#">
                  <i class="material-icons pr-2">format_list_bulleted</i>
                  Customers
                </nuxt-link>
              </li>
              <li class="nav-item">
                <nuxt-link to="/customers/customer" class="nav-link" href="#">
                  <i class="material-icons pr-2">control_point</i>
                  Add Customer
                </nuxt-link>
              </li>
            </ul>

          <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
            <span>Projects</span>
          </h6>
          <ul class="nav flex-column mb-2">
            <li class="nav-item">
              <nuxt-link to="/projects" class="nav-link" href="#">
                <i class="material-icons pr-2">format_list_bulleted</i>
                Projects
              </nuxt-link>
            </li>
            <li class="nav-item">
              <nuxt-link to="/projects/project" class="nav-link" href="#">
                <i class="material-icons pr-2">control_point</i>
                Add Project
              </nuxt-link>
            </li>
            <li class="nav-item">
              <nuxt-link to="/projects/workedhours/" class="nav-link" href="#">
                <i class="material-icons pr-2">format_list_bulleted</i>
                Worked Hours
              </nuxt-link>
            </li>
            <li class="nav-item">
              <nuxt-link to="/projects/workedhours/hours" class="nav-link" href="#">
                <i class="material-icons pr-2">control_point</i>
                Add Worked Hours
              </nuxt-link>
            </li>
          </ul>
          <h6>
            <span class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">Website TODO</span>
          </h6>
          <ul class="nav flex-column mb-2">
            <li class="nav-item">
              <nuxt-link to="/todo" class="nav-link">
              TODO
              </nuxt-link>
            </li>
          </ul>
        </div>
      </nav>
      <main class="col-md-9 ml-sm-auto col-lg-10 px-4 pt-3" role="main">
        <nuxt />
      </main>  
    </div>        
  </div>
</div>
</template>