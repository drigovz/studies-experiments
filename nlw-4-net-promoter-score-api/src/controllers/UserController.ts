import { Request, Response } from 'express';
import { getCustomRepository } from 'typeorm';
import { UserRepository } from '../repositories/UsersRepository';
import * as yup from 'yup';
import { AppError } from '../errors/AppError';

class UserController {
    async create(req: Request, res: Response) {
        const { name, email } = req.body;

        const schema = yup.object().shape({
            name: yup.string().required("Name is required"),
            email: yup.string().email("E-mail not valid").required("E-mail is required")
        });

        try {
            await schema.validate(req.body, { abortEarly: false });
        } catch (err) {
            throw new AppError(err);
        }

        const userRepository = getCustomRepository(UserRepository);

        const user = userRepository.create({
            name,
            email
        });

        const userAlreadyExists = await userRepository.findOne({
            email
        });

        if (userAlreadyExists)
            throw new AppError("User already exists!");

        await userRepository.save(user);

        return res.status(201).json(user);
    }
}

export { UserController };