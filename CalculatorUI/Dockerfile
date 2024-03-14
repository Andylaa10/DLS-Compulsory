# Stage 1: Build Angular app
FROM node:20 as build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build -- --prod

# Stage 2: Serve Angular app with Nginx
FROM nginx:latest
COPY --from=build /app/dist/CalculatorUI /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
