FROM node:20.1 as build
WORKDIR /app
COPY /CalculatorUI/package.json ./package.json
RUN npm install
RUN npm install -g @angular/cli
COPY /CalculatorUI/ ./
RUN ng build
FROM nginx:alpine
COPY --from=build /app/dist/calculator-ui/browser /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

