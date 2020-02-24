import pkg from './package'

export default {
  mode: 'spa',

  /*
  ** Headers of the page
  */
  head: {
    title: pkg.name,
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: pkg.description }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
      ,{ rel: 'stylesheet', href:"https://fonts.googleapis.com/icon?family=Material+Icons"}
    ]
  },

  /*
  ** Customize the progress-bar color
  */
  loading: { color: '#fff' },

  /*
  ** Global CSS
  */
  css: [
    '~assets/css/style.css',
  ],

  /*
  ** Plugins to load before mounting the App
  */
  plugins: [
    {src:'~/plugins/axios-https.js'},
    {src:'~/plugins/global-components.js'},
    {src:'~/plugins/datepicker.client.js'},
    {src:'~/plugins/calendar.client.js'},
    {src:'~/plugins/utils.js'},
    {src:'~/plugins/apiManager.js'},
    {src:'~plugins/format-currency.js'},
  ],

  /*
  ** Nuxt.js modules
  */
 modules: [
  // Doc: https://axios.nuxtjs.org/usage
  '@nuxtjs/axios',
  // Doc: https://bootstrap-vue.js.org/docs/
  'bootstrap-vue/nuxt',
],
  /*
  ** Axios module configuration
  */
  axios: {
    
  },
  env:{
    
  },
  /*
  ** Build configuration
  */
  build: {
    /*
    ** You can extend webpack config here
    */
    extend(config, ctx) {
    }
  }
}
