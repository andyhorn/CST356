import Vue from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import AxiosPlugin from 'vue-axios-cors';

Vue.config.productionTip = false
Vue.use(VueAxios, axios);
Vue.use(AxiosPlugin);

new Vue({
  render: h => h(App),
  router,
}).$mount('#app')
