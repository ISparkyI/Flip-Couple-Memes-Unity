using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{
    private static int LanguageId;

    private static List<TranslatableText> listId = new List<TranslatableText>();

    #region Весть Текст {двухвимірний масив}

    private static string[,] LineText =
    {
        #region US
        {
            "Settings", //0
            "Select the difficulty", //1
            "Sounds", //2
            "Music", //3
            "Language", //4
            "English", //5
            "Beginner", //6
            "Easy", //7
            "Medium", //8
            "Hard", //9
            "Unreal", //10
            "Level", //11
            "Play", //12
            "Cards", //13
            "Collection of cards", //14
            "Animals Memes", //15
            "Random Memes 1", //16
            "Nice try !!", //17
            "Good job !!", //18
            "Well Done !!", //19
            "Wonderfully !!", //20
            "Do it again !!", //21
            "Next", //22
            "Rules", //23
            "This game is similar to Memory, and its goal is to develop your memory skills.\r\n\r\nWhat to do?\r\n1. At the beginning of the game, all cards are face down, and your task is to find all the pairs of cards.\r\n2. When you find a pair of cards, they disappear.\r\n3. When you find all the pairs, the game ends, and you earn coins.\r\n\r\nWhy are coins needed?\r\n1. With coins, you can get hints, which cost 12 coins.\r\n2. You can also skip a level if it's difficult.\r\n3. Accumulate coins; in the future, new decks of cards with memes will be available for purchase using coins.\r\n\r\nWhat to do if the level is easy or difficult?\r\n1. In settings, you can change the game's difficulty level, thus altering the number of pairs you need to find.\r\n2. You can also change the language in settings.\r\n3. Turn music or sounds on or off." //24
        },
        #endregion

        #region UA
        {
            "Налаштування", //0
            "Обери складність", //1
            "Звуки", //2
            "Музика", //3
            "Мова", //4
            "Українська", //5
            "Початковий", //6
            "Легкий", //7
            "Середній", //8
            "Важкий", //9
            "Нереальний", //10
            "Рівень", //11
            "Грати", //12
            "Картки", //13
            "Збірник карток", //14
            "Меми з тваринами", //15
            "Рандомні меми 1", //16
            "Хороша спроба !!", //17
            "Хороша робота !!", //18
            "Файно !!", //19
            "Чудово !!", //20
            "Кращий !!", //21
            "Далі", //22
            "Правила", //23
            "Це гра, схожа на Memory. Мета гри - розвивати вашу пам'ять.\r\n\r\nЩо робити?\r\n1. Коли гра починається, всі картки перевернуті. Ваша задача - знайти всі пари карток.\r\n2. Якщо ви знаходите пару карток, вони зникають.\r\n3. Коли ви знаходите всі пари, гра завершується, і вам зараховуються монети.\r\n\r\nНавіщо потрібні монети?\r\n1. За монети ви можете купити підказку, вона коштує 12 монет.\r\n2. Також ви можете пропустити рівень, якщо він складний.\r\n3. Накопичуйте монети; в майбутньому будуть доступні нові колоди карток з мемами, які ви зможете купити за монети.\r\n\r\nЩо робити, якщо рівень простий або складний?\r\n1. У налаштуваннях ви можете змінити рівень складності гри, таким чином, ви зміните кількість пар, яких вам знадобиться знайти.\r\n2. Також у налаштуваннях ви можете змінити мову.\r\n3. Включити або виключити музику або звуки." //24
        },
        #endregion

        #region RU
        {
            "Настройки", //0
            "Выбери сложность", //1
            "Звуки", //2
            "Музыка", //3
            "Язык", //4
            "Русский", //5
            "Начальный", //6
            "Легкий", //7
            "Средний", //8
            "Сложный", //9
            "Нереальный", //10
            "Уровень", //11
            "Играть", //12
            "Карты", //13
            "Сборник карт", //14
            "Мемы с животными", //15
            "Рандомные мемы 1", //16
            "Хорошая попытка !!", //17
            "Хорошая работа !!", //18
            "Превосходно !!", //19
            "Отлично !!", //20
            "Лучший !!", //21
            "Далее", //22
            "Правила", //23
            "Это игра, похожая на Memory, цель которой - развивать вашу память.\r\n\r\nЧто делать?\r\n1. Когда игра начинается, все карты перевернуты лицом вниз, ваша задача - найти все пары карт.\r\n2. Если вы нашли пару карт, они исчезают.\r\n3. Когда вы найдете все пары, игра завершается, и вам начисляются монеты.\r\n\r\nЗачем нужны монеты?\r\n1. За монеты вы можете получить подсказку, которая стоит 12 монет.\r\n2. Вы также можете пропустить уровень, если он сложный.\r\n3. Накапливайте монеты; в будущем будут доступны новые колоды карт с мемами, которые вы сможете купить за монеты.\r\n\r\nЧто делать, если уровень легкий или сложный?\r\n1. В настройках вы можете изменить уровень сложности игры, изменяя количество пар, которые вам нужно найти.\r\n2. Вы также можете изменить язык в настройках.\r\n3. Включить или выключить музыку или звуки." //24
        },
        #endregion

        #region FR
        {
            "Réglages", //0
            "Sélection de la difficulté", //1
            "Sons", //2
            "Musique", //3
            "Langue", //4
            "Français", //5
            "Débutant", //6
            "Facile", //7
            "Moyen", //8
            "Difficile", //9
            "Unreal", //10
            "Niveau", //11
            "Jouer", //12
            "Cartes", //13
            "Collection ", //14
            "Animaux Memes", //15
            "Mémos aléatoires 1", //16
            "Bien essayé !!", //17
            "Bon travail !!", //18
            "Bien fait !!", //19
            "Merveilleusement !!", //20
            "Recommencez !!", //21
            "Suivant", //22
            "Règles", //23
            "Ce jeu est similaire à Memory, et son but est de développer vos capacités de mémoire.\r\n\r\nQue faire ?\r\n1. Au début du jeu, toutes les cartes sont cachées et votre tâche consiste à trouver toutes les paires de cartes.\r\n2. Lorsque vous trouvez une paire de cartes, elle disparaît.\r\n3. Lorsque vous avez trouvé toutes les paires, le jeu se termine et vous gagnez des pièces.\r\n\r\nPourquoi a-t-on besoin de pièces ?\r\n1. Avec les pièces, vous pouvez obtenir des indices, qui coûtent 12 pièces.\r\n2. Vous pouvez également passer un niveau s'il est difficile.\r\n3. Accumulez des pièces ; à l'avenir, de nouveaux jeux de cartes avec des mèmes seront disponibles à l'achat avec des pièces.\r\n\r\nQue faire si le niveau est facile ou difficile ?\r\n1. Dans les paramètres, vous pouvez changer le niveau de difficulté du jeu, ce qui modifie le nombre de paires à trouver.\r\n2. Vous pouvez également changer la langue dans les paramètres.\r\n3. Activez ou désactivez la musique ou les sons." //24
        },
        #endregion
    };
    #endregion

    static public void Select_language(int id)
    {
        LanguageId = id;
        Update_texts();
    }

    static public string Get_text(int textKey)
    {
        return LineText[LanguageId, textKey];
    }

    static public void Add(TranslatableText idtext)
    {
        listId.Add(idtext);
    }

    static public void Delete(TranslatableText idtext)
    {
        listId.Remove(idtext);
    }

    static public void Update_texts()
    {
        for(int i = 0; i < listId.Count; i++)
        {
            listId[i].UIText.text = LineText[LanguageId, listId[i].textID];
            if (PlayerPrefs.GetInt("Language") == 1) listId[i].UIText.font = Resources.Load<Font>("RU_font");
            else if (PlayerPrefs.GetInt("Language") == 2) listId[i].UIText.font = Resources.Load<Font>("UA_font");
            else listId[i].UIText.font = Resources.Load<Font>("US_font");

        }
    }
}
