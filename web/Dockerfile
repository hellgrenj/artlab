FROM nginx:1.21.1-alpine as runtime
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY index.html script.js style.css /var/share/nginx/html/
EXPOSE 80