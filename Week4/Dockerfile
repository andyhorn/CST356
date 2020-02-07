# Pull the nginx base image
FROM nginx:alpine

# Copy the nginx configuration file
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf

# Copy the application files
COPY ./build /usr/share/nginx/app/

# Expose the default web port
EXPOSE 80