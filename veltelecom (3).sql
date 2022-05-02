-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 16 2021 г., 00:30
-- Версия сервера: 8.0.12
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `veltelecom`
--

-- --------------------------------------------------------

--
-- Структура таблицы `admin`
--

CREATE TABLE `admin` (
  `id_` int(11) NOT NULL,
  `login_` text NOT NULL,
  `password_` text NOT NULL,
  `Familia` text NOT NULL,
  `Ima` text NOT NULL,
  `Otchestvo` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `admin`
--

INSERT INTO `admin` (`id_`, `login_`, `password_`, `Familia`, `Ima`, `Otchestvo`) VALUES
(1, 'Администратор', '0000', 'Колобов', 'Петр', 'Антонинович');

-- --------------------------------------------------------

--
-- Структура таблицы `data_opl`
--

CREATE TABLE `data_opl` (
  `id_opl` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `data_opl` date NOT NULL,
  `balance` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `data_opl`
--

INSERT INTO `data_opl` (`id_opl`, `id_user`, `data_opl`, `balance`) VALUES
(1, 1, '2021-06-01', 250),
(2, 1, '2021-06-01', 350),
(3, 2, '2021-06-02', 900),
(4, 3, '2021-06-03', 10),
(5, 4, '2021-06-04', 30),
(6, 3, '2021-06-02', 50),
(7, 2, '2021-06-04', 50);

-- --------------------------------------------------------

--
-- Структура таблицы `delete_users`
--

CREATE TABLE `delete_users` (
  `id_` int(11) NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `delete_users`
--

INSERT INTO `delete_users` (`id_`, `id_user`) VALUES
(1, 1),
(2, 2),
(4, 4),
(5, 9);

-- --------------------------------------------------------

--
-- Структура таблицы `lock_internet`
--

CREATE TABLE `lock_internet` (
  `id_Lock` int(11) NOT NULL,
  `data_1` date NOT NULL,
  `data_2` date NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `lock_internet`
--

INSERT INTO `lock_internet` (`id_Lock`, `data_1`, `data_2`, `id_user`) VALUES
(1, '2021-06-04', '2021-06-05', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `login_`
--

CREATE TABLE `login_` (
  `id_login` int(11) NOT NULL,
  `login_` varchar(40) NOT NULL,
  `passwords` varchar(40) NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `login_`
--

INSERT INTO `login_` (`id_login`, `login_`, `passwords`, `id_user`) VALUES
(1, 'ProklSnezhnyy620', 'TiUAeY1GRDYp', 1),
(2, 'DomnaGronskaya591', 'mwNd5KusOe8P', 6),
(3, '321322', 'fifwefbewi', 2),
(4, 'dasdashdasu', 'fnhweuwef', 3),
(5, 'fhewuifwe', 'dmsdsdbvdsbv', 4),
(6, 'AHFufgweb', 'feuwfhew', 5),
(7, '3', '3', 7),
(9, 'RadaKonyagina429', 'VhBA6yqM39wq', 9);

-- --------------------------------------------------------

--
-- Структура таблицы `predstavitel`
--

CREATE TABLE `predstavitel` (
  `id_predstavitel` int(11) NOT NULL,
  `Familia` varchar(50) NOT NULL,
  `Ima` varchar(50) NOT NULL,
  `Otchestvo` varchar(50) NOT NULL,
  `NumberPhone` varchar(20) NOT NULL,
  `Inn` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `predstavitel`
--

INSERT INTO `predstavitel` (`id_predstavitel`, `Familia`, `Ima`, `Otchestvo`, `NumberPhone`, `Inn`) VALUES
(1, 'Фадеева', 'Георгьевна', 'Георгьевна', '7846151615', '123321123123'),
(2, 'Шашков', 'Авраам', 'Макарович', '79449161549', '225541513154'),
(3, 'Шпагин', 'Сигизмунд', 'Закирович', '79340865024', '122529988543'),
(4, 'Любимова', 'Регина', 'Борисовна', '79781352644', '922529968542'),
(5, 'Литвинова', 'Агнесса', 'Валерьевна', '79441617475', '589651115621'),
(6, 'Конягина', 'Джульетта', 'Игоревна', '79264753440', '225455555615');

-- --------------------------------------------------------

--
-- Структура таблицы `provader`
--

CREATE TABLE `provader` (
  `ID_Provader` int(11) NOT NULL,
  `Name_provadeer` text NOT NULL,
  `id_predstavitel` int(11) NOT NULL,
  `INN` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `provader`
--

INSERT INTO `provader` (`ID_Provader`, `Name_provadeer`, `id_predstavitel`, `INN`) VALUES
(1, 'Мегафон', 1, '123321123123'),
(2, 'МТС', 2, '22554151315'),
(3, 'ТЕЛЕ2', 3, '22554151315'),
(4, 'Ростелеком', 4, '22554151315'),
(5, 'Билайн', 5, '22554151315'),
(6, 'Триколор', 6, '22554151315');

-- --------------------------------------------------------

--
-- Структура таблицы `server`
--

CREATE TABLE `server` (
  `ID_Server_Tarif` int(11) NOT NULL,
  `name_server` varchar(40) NOT NULL,
  `ip_server` varchar(40) NOT NULL,
  `ID_Provader` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `server`
--

INSERT INTO `server` (`ID_Server_Tarif`, `name_server`, `ip_server`, `ID_Provader`) VALUES
(1, 'Главный сервер', '125.0.0.1', 1),
(2, 'Телевидение + интернет', '173.0.0.2', 6),
(3, 'Интернет (повышенная скорость)', '115.0.0.1', 3),
(4, 'ДЛЯ ООО/Образовательных', '135.0.0.1', 4),
(5, 'Запасной сервер(ТВ+ИНТЕРНЕТ)', '185.0.0.1', 5);

-- --------------------------------------------------------

--
-- Структура таблицы `tariff`
--

CREATE TABLE `tariff` (
  `ID_Tarif` int(11) NOT NULL,
  `ID_server_tarif` int(11) NOT NULL,
  `Cena_Mes` int(11) NOT NULL,
  `Name_Tarif` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tariff`
--

INSERT INTO `tariff` (`ID_Tarif`, `ID_server_tarif`, `Cena_Mes`, `Name_Tarif`) VALUES
(15, 1, 550, 'Стандарт'),
(16, 1, 850, 'Расширенный'),
(17, 2, 1500, 'ТВ+Интернет'),
(18, 3, 1000, 'Домашний'),
(19, 4, 900, 'Рабочий'),
(20, 4, 2000, 'Образовательный'),
(21, 5, 450, 'Мобильный');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id_user` int(11) NOT NULL,
  `Familia` varchar(20) NOT NULL,
  `Ima` varchar(20) NOT NULL,
  `Otchestvo` varchar(20) NOT NULL,
  `Telephon` varchar(11) NOT NULL,
  `Emaile` varchar(50) NOT NULL,
  `Adres` varchar(100) NOT NULL,
  `balance` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id_user`, `Familia`, `Ima`, `Otchestvo`, `Telephon`, `Emaile`, `Adres`, `balance`) VALUES
(1, 'Снежный', 'Прокл', 'Макарович', '79448165636', 'fiql03@amazingmail.xyz', '187550, г. Апшеронск, ул. Клинский проезд, дом 16, квартира 601', 0),
(2, 'Федотова', 'Сильвия', 'Викторовна', '79264927854', 'wwjwav@amazingmail.xyz', '646055, г. Сатинка, ул. Междуреченская, дом 16, квартира 718', 0),
(3, 'Кузьмина', 'Мирослава', 'Станиславовна', '79584978483', 'wwjwav@amazingmail.xyz', '422485, г. Подольск, ул. Ельцовка, дом 104, квартира 375', 0),
(4, 'Безруков', 'Измаил', 'Максимович', '79011873288', 'Ndqwuwqd@amazingmail.xyz', '433977, г. Енотаевка, ул. Вольная, дом 171, квартира 306', 202),
(5, 'Абрамов', 'Елисей', 'Демьянович', '79558554545', 'fisa5s@gmail.xyz', '161111, г. Лермонтов, ул. Цветной пер, дом 99, квартира 221\r\n', 1000),
(6, 'Волощук', 'Леонид', 'Игоревич', '79243893162', 'ndassudas@gmail.com', '416463, г. Пермь, ул. Майкова, дом 4, квартира 262', 300),
(7, 'Зайцев', 'Юрий', 'Иванович', '79211111111', 'dsadasdsa@gmail.com', '410899, г. Яр, ул. Академика Сахарова парк, дом 177, квартира 339', 520),
(9, 'Конягина', 'Рада', 'Константиновна', '79200956888', '0dshl0@bestmail.monster', '352900, г. Целинное, ул. Каштановая М. аллея, дом 165, квартира 521', 200);

-- --------------------------------------------------------

--
-- Структура таблицы `zakaz`
--

CREATE TABLE `zakaz` (
  `Id_zakaz` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `ID_Tarif` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `zakaz`
--

INSERT INTO `zakaz` (`Id_zakaz`, `id_user`, `ID_Tarif`) VALUES
(1, 1, 15),
(2, 2, 21),
(3, 3, 19),
(7, 6, 21),
(8, 4, 15),
(9, 5, 15),
(10, 7, 18),
(12, 9, 17);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id_`);

--
-- Индексы таблицы `data_opl`
--
ALTER TABLE `data_opl`
  ADD PRIMARY KEY (`id_opl`);

--
-- Индексы таблицы `delete_users`
--
ALTER TABLE `delete_users`
  ADD PRIMARY KEY (`id_`),
  ADD KEY `fk_delete_users_users1_idx` (`id_user`);

--
-- Индексы таблицы `lock_internet`
--
ALTER TABLE `lock_internet`
  ADD PRIMARY KEY (`id_Lock`);

--
-- Индексы таблицы `login_`
--
ALTER TABLE `login_`
  ADD PRIMARY KEY (`id_login`),
  ADD KEY `fk_login__users1_idx` (`id_user`);

--
-- Индексы таблицы `predstavitel`
--
ALTER TABLE `predstavitel`
  ADD PRIMARY KEY (`id_predstavitel`);

--
-- Индексы таблицы `provader`
--
ALTER TABLE `provader`
  ADD PRIMARY KEY (`ID_Provader`),
  ADD KEY `fk_provader_predstavitel_idx` (`id_predstavitel`);

--
-- Индексы таблицы `server`
--
ALTER TABLE `server`
  ADD PRIMARY KEY (`ID_Server_Tarif`),
  ADD KEY `fk_server_provader1_idx` (`ID_Provader`);

--
-- Индексы таблицы `tariff`
--
ALTER TABLE `tariff`
  ADD PRIMARY KEY (`ID_Tarif`),
  ADD KEY `fk_tariff_server1_idx` (`ID_server_tarif`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id_user`);

--
-- Индексы таблицы `zakaz`
--
ALTER TABLE `zakaz`
  ADD PRIMARY KEY (`Id_zakaz`),
  ADD KEY `fk_zakaz_users1_idx` (`id_user`),
  ADD KEY `fk_zakaz_tariff1_idx` (`ID_Tarif`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `admin`
--
ALTER TABLE `admin`
  MODIFY `id_` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `data_opl`
--
ALTER TABLE `data_opl`
  MODIFY `id_opl` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `delete_users`
--
ALTER TABLE `delete_users`
  MODIFY `id_` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `lock_internet`
--
ALTER TABLE `lock_internet`
  MODIFY `id_Lock` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `login_`
--
ALTER TABLE `login_`
  MODIFY `id_login` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `predstavitel`
--
ALTER TABLE `predstavitel`
  MODIFY `id_predstavitel` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `provader`
--
ALTER TABLE `provader`
  MODIFY `ID_Provader` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `server`
--
ALTER TABLE `server`
  MODIFY `ID_Server_Tarif` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `tariff`
--
ALTER TABLE `tariff`
  MODIFY `ID_Tarif` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `zakaz`
--
ALTER TABLE `zakaz`
  MODIFY `Id_zakaz` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `delete_users`
--
ALTER TABLE `delete_users`
  ADD CONSTRAINT `fk_delete_users_users1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`);

--
-- Ограничения внешнего ключа таблицы `login_`
--
ALTER TABLE `login_`
  ADD CONSTRAINT `fk_login__users1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`);

--
-- Ограничения внешнего ключа таблицы `provader`
--
ALTER TABLE `provader`
  ADD CONSTRAINT `fk_provader_predstavitel` FOREIGN KEY (`id_predstavitel`) REFERENCES `predstavitel` (`id_predstavitel`);

--
-- Ограничения внешнего ключа таблицы `server`
--
ALTER TABLE `server`
  ADD CONSTRAINT `fk_server_provader1` FOREIGN KEY (`ID_Provader`) REFERENCES `provader` (`id_provader`);

--
-- Ограничения внешнего ключа таблицы `tariff`
--
ALTER TABLE `tariff`
  ADD CONSTRAINT `fk_tariff_server1` FOREIGN KEY (`ID_server_tarif`) REFERENCES `server` (`id_server_tarif`);

--
-- Ограничения внешнего ключа таблицы `zakaz`
--
ALTER TABLE `zakaz`
  ADD CONSTRAINT `fk_zakaz_tariff1` FOREIGN KEY (`ID_Tarif`) REFERENCES `tariff` (`id_tarif`),
  ADD CONSTRAINT `fk_zakaz_users1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
