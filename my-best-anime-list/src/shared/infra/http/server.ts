import express from 'express';
import cors from 'cors';
import routes from './routes';

const port = '3333' || process.env.PORT;

const app = express();
app.use(cors());
app.use(express.json());
app.use(routes);

app.listen(port, () => {
  console.log(
    `\n\n  \x1b[32m Node.js v${process.versions.node} \x1b[0m \n`,
    `  Running on: ${process.platform.toUpperCase()} ${process.arch}  \n`,
    `  PID: ${process.pid}  \n`,
    ` 🏆 Server is running on \x1b[33m http://localhost:${port} 🏆 \x1b[0m \n\n`,
  );
});
