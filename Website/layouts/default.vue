<template>
  <div class="container-fluid">
    <div class="row">
      <nav class="col-md-2 d-none d-md-block sidebar dark">
        <div class="sidebar-sticky">
          <h1 class="ml-3 text-info">ucrm</h1>
          <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted title">
            <span>Reports</span>
          </h6>
          <ul class="nav flex-column">
            <li class="nav-item">
              <nuxt-link to="/" class="nav-link" href="#">
                <i class="material-icons pr-2">format_list_bulleted</i>
                  Dashboard <span class="sr-only">(current)</span>
              </nuxt-link>
            </li>
            <li class="nav-item">
              <nuxt-link to="/stats" class="nav-link" href="#">
                <i class="material-icons pr-2">format_list_bulleted</i>
                  Annual Incomings
              </nuxt-link>
            </li>
          </ul>
            <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted title">
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

          <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted title">
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
        </div>
      </nav>
      <main class="col-md-9 ml-sm-auto col-lg-10 px-4 pt-3" role="main">
        <nuxt />
      </main>  
    </div>        
  </div>
</template>
<style scoped>
.dark{
  background-color: #000;
}
.nav-item a {
  color: #666;
  text-transform: uppercase;
}
.text-muted {
  color:#6bd098 !important;
}
</style>