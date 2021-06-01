using System;

namespace RSA_Fedor_lib
{
    public class RSA_Fedor_lib_object
    {
        const int max = 500;
        bool[] p1 = new bool[max];
        bool[] p2 = new bool[max];
        bool[] n = new bool[max];
        bool[] key_public = new bool[max];
        bool[] key_private = new bool[max];
        char[] text = new char[62];
        public int maxblock = 10;
        Random rand = new Random();
        public void draw(bool[] a)
        {
            bool begin = false;
            for (int go = 0; go < max; go++)
            {
                if (a[go] == true) { begin = true; }
                if (begin == true)
                {
                    if (a[go] == false)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("1");
                    }
                }
            }
            if (begin == false) { Console.Write("0"); }
        }
        public void plus(bool[] a, bool[] b, int up_b, bool[] back)
        {
            bool step = false;
            bool[] back_ = new bool[max];
            int go = max - 1;
            bool aa, bb;
            while (go >= 0)
            {
                aa = a[go];
                if (go + up_b >= max)
                {
                    bb = false;
                }
                else
                {
                    bb = b[go + up_b];
                }
                if ((aa == true) && (bb == true))
                {
                    if (step == true)
                    {
                        back_[go] = true;
                    }
                    else
                    {
                        step = true;
                        back_[go] = false;
                    }
                }
                else
                {
                    if ((aa == false) && (bb == false))
                    {
                        if (step == true)
                        {
                            step = false;
                            back_[go] = true;
                        }
                        else
                        {
                            back_[go] = false;
                        }
                    }
                    else
                    {
                        //TF or FT
                        if (step == true)
                        {
                            back_[go] = false;
                        }
                        else
                        {
                            back_[go] = true;
                        }
                    }
                }
                go--;
            }
            for (go = 0; go < max; go++)
            {
                back[go] = back_[go];
            }
        }
        public void plus_dig(bool[] a, int dig, bool[] back)
        {
            bool step = false;
            bool[] back_ = new bool[max];
            int go = max - 1;
            bool aa, bb;
            while (go >= 0)
            {
                aa = a[go];
                if (go == max - 1 - dig)
                {
                    bb = true;
                }
                else
                {
                    bb = false;
                }
                if ((aa == true) && (bb == true))
                {
                    if (step == true)
                    {
                        back_[go] = true;
                    }
                    else
                    {
                        step = true;
                        back_[go] = false;
                    }
                }
                else
                {
                    if ((aa == false) && (bb == false))
                    {
                        if (step == true)
                        {
                            step = false;
                            back_[go] = true;
                        }
                        else
                        {
                            back_[go] = false;
                        }
                    }
                    else
                    {
                        //TF or FT
                        if (step == true)
                        {
                            back_[go] = false;
                        }
                        else
                        {
                            back_[go] = true;
                        }
                    }
                }
                go--;
            }
            for (go = 0; go < max; go++)
            {
                back[go] = back_[go];
            }
        }
        public void minus(bool[] a, bool[] b, int up_b, bool[] back)
        {
            bool step = false;
            bool[] back_ = new bool[max];
            int go = max - 1;
            bool aa, bb;
            while (go >= 0)
            {
                aa = a[go];
                if (go + up_b >= max)
                {
                    bb = false;
                }
                else
                {
                    bb = b[go + up_b];
                }
                if (aa == bb)
                {
                    if (step == true)
                    {
                        back_[go] = true;
                    }
                    else
                    {
                        back_[go] = false;
                    }
                }
                else
                {
                    if ((aa == true) && (bb == false))
                    {
                        if (step == true)
                        {
                            step = false;
                            back_[go] = false;
                        }
                        else
                        {
                            back_[go] = true;
                        }
                    }
                    else
                    {
                        if ((aa == false) && (bb == true))
                        {
                            if (step == true)
                            {
                                back_[go] = false;
                            }
                            else
                            {
                                step = true;
                                back_[go] = true;
                            }
                        }
                    }
                }
                go--;
            }
            for (go = 0; go < max; go++)
            {
                back[go] = back_[go];
            }
        }
        public void multiplicate(bool[] a, bool[] b, bool[] back)
        {
            bool[] back_ = new bool[max];
            int go;
            for (go = 0; go < max; go++)
            {
                back_[go] = false;
            }

            go = max - 1;
            int up = 0;
            while (go >= 0)
            {
                if (b[go] == true)
                {
                    plus(back_, a, up, back_);
                }
                up++;
                go--;
            }

            for (go = 0; go < max; go++)
            {
                back[go] = back_[go];
            }
        }
        public bool bigger(bool[] a, bool[] b, int up_b, bool ifequal)
        {
            int go = 0;
            while (go < max - up_b)
            {
                if ((a[go] == false) && (b[go + up_b] == true))
                {
                    return false;
                }
                if ((a[go] == true) && (b[go + up_b] == false))
                {
                    return true;
                }
                go++;
            }
            while (go < max)
            {
                if (a[go] == true)
                {
                    return true;
                }
                go++;
            }
            return ifequal;
        }
        public bool equal(bool[] a, bool[] b, int b_up)
        {
            for (int go = 0; go < max - b_up; go++) { if (a[go] != b[go + b_up]) { return false; } }
            for (int go = max - b_up; go < max; go++) { if (a[go] == true) { return false; } }
            return true;
        }
        public void divide(bool[] a, bool[] b, bool[] back, bool[] back_rest)
        {
            bool[] back_ = new bool[max];
            bool[] a_ = new bool[max];
            int go;
            for (go = 0; go < max; go++)
            {
                back_[go] = false;
                a_[go] = a[go];
            }

            int run;
            while (bigger(b, a_, 0, false) == false)
            {
                run = 0;
                while (bigger(a_, b, run, true) == true) { run++; }
                if (equal(a_, b, run) == false) { run--; }
                back_[max - 1 - run] = true;
                minus(a_, b, run, a_);
            }
            for (go = 0; go < max; go++)
            {
                back[go] = back_[go];
                back_rest[go] = a_[go];
            }
        }
        public bool is_dig(bool[] a, int digit)//digit=max for checking 0
        {
            if ((digit != max) && (a[max - 1 - digit] != true)) { return false; }
            for (int go = 0; go < max; go++) { if ((a[go] == true) && (go != max - 1 - digit)) { return false; } }
            return true;
        }
        public bool is_prime(bool[] number)
        {
            //number prime then 1*2^number=2(mod number)
            //bas=2,mul=1,power=number
            bool[] power = new bool[max];
            bool[] bas = new bool[max];
            bool[] mul = new bool[max];
            bool[] junk = new bool[max];

            for (int go = 0; go < max; go++)
            {
                power[go] = number[go];
                bas[go] = false;
                mul[go] = false;
            }

            bas[max - 2] = true;
            mul[max - 1] = true;

            while (is_dig(power, 0) == false)
            {
                if (power[max - 1] == true)
                {
                    multiplicate(mul, bas, mul);
                    divide(mul, number, junk, mul);
                }
                multiplicate(bas, bas, bas);
                divide(bas, number, junk, bas);
                for (int go = max - 1; go > 0; go--) { power[go] = power[go - 1]; }
                power[0] = false;
            }
            multiplicate(mul, bas, mul);
            divide(mul, number, junk, mul);
            if (is_dig(mul, 1) == true)
            {
                return true;
            }
            return false;
        }
        public void mod(bool[] bas_, bool[] power_, bool[] number, bool[] back)
        {
            //bas^power(mod number)
            bool[] power = new bool[max];
            bool[] bas = new bool[max];
            bool[] mul = new bool[max];
            bool[] junk = new bool[max];

            for (int go = 0; go < max; go++)
            {
                power[go] = power_[go];
                bas[go] = bas_[go];
                mul[go] = false;
            }

            mul[max - 1] = true;

            while (is_dig(power, 0) == false)
            {
                if (power[max - 1] == true)
                {
                    multiplicate(mul, bas, mul);
                    divide(mul, number, junk, mul);
                }
                multiplicate(bas, bas, bas);
                divide(bas, number, junk, bas);
                for (int go = max - 1; go > 0; go--) { power[go] = power[go - 1]; }
                power[0] = false;
            }
            multiplicate(mul, bas, mul);
            divide(mul, number, junk, mul);

            for (int go = 0; go < max; go++) { back[go] = mul[go]; }
        }
        public void generate_prime(bool[] p, int dig, int dif, int id, bool id_dig)
        {
            for (int g = 0; g < max; g++) { p[g] = false; }
            p[max - 1 - id] = id_dig;
            p[max - dig] = true;
            p[max - 1] = true;
            int gg = 0, r;
            while (gg < dif)
            {
                r = rand.Next(1, dig - 2);
                r = r % (dig - 2);
                if ((r != 0) && (r != max - 1 - id) && (p[max - 1 - r] == false))
                {
                    p[max - 1 - r] = true;
                    gg++;
                }
            }
            while (is_prime(p) == false) { plus_dig(p, 1, p); }
        }
        public void generate_keys(bool[] public_key, bool[] private_key, bool[] N, int dig, int dif)
        {
            bool[] p1 = new bool[max];
            bool[] p2 = new bool[max];
            bool[] e = new bool[max];
            bool[] k = new bool[max];
            bool[] rest = new bool[max];
            for (int go = 0; go < max; go++)
            {
                e[go] = false;
                rest[go] = false;
                p1[go] = false;
                p2[go] = false;
            }
            int id = rand.Next(1, dig);
            generate_prime(p1, dig, dif, id, false);
            generate_prime(p2, dig, dif, id, true);
            multiplicate(p1, p2, N);
            e[max - 1] = true;//temporary use e like 1 to do minus one
            minus(p1, e, 0, p1);
            minus(p2, e, 0, p2);
            multiplicate(p1, p2, e);

            for (int go = 0; go < max; go++) { public_key[go] = false; }
            public_key[max - 1] = true;

            rest[max - 1] = true;

            while (is_dig(rest, max) == false)
            {
                plus_dig(public_key, 0, public_key);

                for (int go = 0; go < max; go++) { private_key[go] = false; }
                multiplicate(k, e, private_key);
                plus_dig(private_key, 0, private_key);
                if (bigger(public_key, private_key, 0, true) == true)
                {
                    for (int go = 0; go < max; go++) { public_key[go] = false; }
                    public_key[max - 1] = true;
                    plus_dig(k, 0, k);
                }
                else
                {
                    divide(private_key, public_key, private_key, rest);
                }
            }
        }
        public void generate_keys_correct(bool[] public_key, bool[] private_key, bool[] N, int dig, int dif)
        {
            bool again = true;
            bool[] msg = new bool[max];
            bool[] msg_ = new bool[max];
            while (again == true)
            {
                generate_keys(public_key, private_key, N, dig, dif);
                again = false;

                for (int go = 0; go < max; go++) { msg[go] = false; }
                int run = 2;
                int run_ = dig / 5;
                if (run_ < 2) { run_ = 2; }
                while (run < dig)
                {
                    plus_dig(msg, run, msg);
                    for (int go = 0; go < max; go++) { msg_[go] = msg[go]; }
                    code(msg, public_key, N);
                    decode(msg, private_key, N);
                    if (equal(msg, msg_, 0) == false)
                    {
                        run = dig;
                        again = true;
                        Console.WriteLine("Generating again");
                    }
                    run += run_;
                }
            }
        }
        public void code(bool[] msg, bool[] public_key, bool[] n)
        {
            mod(msg, public_key, n, msg);
        }
        public void decode(bool[] msg, bool[] private_key, bool[] n)
        {
            mod(msg, private_key, n, msg);
        }
        public void text_to_binar(char[] text, bool[] p)
        {
            int char_go = 0;
            while (text[char_go + 1] != '\0') { char_go++; }
            int bool_go = max - 1;
            int letter;
            for (bool_go = 0; bool_go < max; bool_go++) { p[bool_go] = false; }
            bool_go = max - 1;
            while (char_go >= 0)
            {
                letter = (int)(text[char_go]);
                if (letter >= 128) { p[bool_go - 7] = true; letter -= 128; }
                if (letter >= 64) { p[bool_go - 6] = true; letter -= 64; }
                if (letter >= 32) { p[bool_go - 5] = true; letter -= 32; }
                if (letter >= 16) { p[bool_go - 4] = true; letter -= 16; }
                if (letter >= 8) { p[bool_go - 3] = true; letter -= 8; }
                if (letter >= 4) { p[bool_go - 2] = true; letter -= 4; }
                if (letter >= 2) { p[bool_go - 1] = true; letter -= 2; }
                if (letter >= 1) { p[bool_go - 0] = true; letter -= 1; }
                char_go -= 1;
                bool_go -= 8;
            }
        }
        public void binar_to_text(bool[] p, char[] text)
        {
            int bool_go = max - 1;
            int char_go = 0;
            int letter = 1;
            while (letter != 0)
            {
                if (
                    (p[bool_go - 0] == false) &&
                    (p[bool_go - 1] == false) &&
                    (p[bool_go - 2] == false) &&
                    (p[bool_go - 3] == false) &&
                    (p[bool_go - 4] == false) &&
                    (p[bool_go - 5] == false) &&
                    (p[bool_go - 6] == false) &&
                    (p[bool_go - 7] == false) &&
                    (p[bool_go - 8] == false)
                ) { letter = 0; }
                else { bool_go -= 8; }
            }
            while (bool_go + 8 < max)
            {
                letter = 0;
                if (p[bool_go + 1] == true) { letter += 128; }
                if (p[bool_go + 2] == true) { letter += 64; }
                if (p[bool_go + 3] == true) { letter += 32; }
                if (p[bool_go + 4] == true) { letter += 16; }
                if (p[bool_go + 5] == true) { letter += 8; }
                if (p[bool_go + 6] == true) { letter += 4; }
                if (p[bool_go + 7] == true) { letter += 2; }
                if (p[bool_go + 8] == true) { letter += 1; }
                text[char_go] = (char)(letter);
                char_go++;
                bool_go += 8;
            }
            text[char_go] = '\0';
        }
        public void text_dir(char[] input)
        {
            for (int go = 0; go < maxblock; go++)
            {
                if (input[0] == '\0')
                {
                    text[go] = ' ';
                }
                else
                {
                    text[go] = input[0];
                    int g = 0;
                    while (input[g + 1] != '\0')
                    {
                        input[g] = input[g + 1];
                        g++;
                    }
                    input[g] = '\0';
                }
            }
        }
        public void text_connect(char[] output)
        {
            int go = 0;
            int ogo = 0;
            while (output[ogo] != '\0') { ogo++; }
            bool doo = true;
            while (doo == true)
            {
                output[ogo] = text[go];
                ogo++;
                go++;
                if (go == maxblock) { doo = false; }
            }
            text[0] = '\0';
            output[ogo] = '\0';
        }
    }
}
