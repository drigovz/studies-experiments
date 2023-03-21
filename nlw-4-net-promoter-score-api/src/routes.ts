import { Router } from 'express';
import { SurveysController } from './controllers/SurveyController';
import { UserController } from './controllers/UserController';
import { SendMailController } from './controllers/SendMailController';
import { AnswerController } from './controllers/AnswerController';
import { NpsController } from './controllers/NpsController';

const router = Router(),
    userController = new UserController(),
    surveysController = new SurveysController(),
    sendMailController = new SendMailController(),
    answerController = new AnswerController(),
    npsController = new NpsController();

router.post("/users", userController.create);
router.post("/surveys", surveysController.create);
router.get("/surveys", surveysController.show);
router.post("/sendMail", sendMailController.execute);
router.get("/answers/:value", answerController.execute);
router.get("/nps/:survey_id", npsController.execute);

export { router };