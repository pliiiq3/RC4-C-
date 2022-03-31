int[] s = new int[256];
string keystr = "RC4EXAM";

public void InitS()
{
    for (int i = 0; i < s.Length; i++)
    {
        s[i] = i;
    }
}


public void KSAKey()
{
    int j = 0;
    for (int i = 0; i < 256; i++)
    {
        j = (j + s[i] + (int)keystr[i % keystr.Length]) % 256;
        int x = s[i];
        s[i] = s[j];
        s[j] = x;
    }
}

public int PRGA(int i, int j)
{
    i = (i + 1) % 256;
    j = (j + s[i]) % 256;
    //swap
    int x = s[i];
    s[i] = s[j];
    s[j] = x;
    return s[(s[i] + s[j]) % 256];
}

//------------------


public int Getk(int i, int j)
{
    i = (i + 1) % 256;
    j = (j + s[i]) % 256;


    for (int i = 0; i < img.Width; i++)
    {
        for (int j = 0; j < img.Height; j++)
        {
            int key = Getk(i, j);
            Color c = b.GetPixel(i, j);
            int r = c.R ^ key;
            int g = c.G ^ key;
            int bl = c.B ^ key;
            c = Color.FromArgb(r, g, bl);
            b.SetPixel(i, j, c);
        }
    }

}

//swap
swap(s[i], s[j]);
 return s[(s[i] + s[j]) % 256];

