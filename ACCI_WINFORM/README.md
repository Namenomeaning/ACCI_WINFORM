docker run -d --name pttkhttt `
  -p 33306:3306 `
  -e MYSQL_ROOT_PASSWORD=root `
  -e MYSQL_DATABASE=ACCI `
  mysql:latest