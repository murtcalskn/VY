
#include <bits/stdc++.h> 
using namespace std;


void findNumbers(vector<int>& ar, int sum,
    vector<vector<int>>& res,
    vector<int>& r, int i)
{
    //Eğer Mevcut toplam negatif olursa
    if (sum < 0)
        return;


    if (sum == 0)
    {
        res.push_back(r);
        return;
    }

    //toplam değerinden listenin elamanlarını çıkar 
    //örnek olarak 8-2-2-2-2=0
    while (i < ar.size() && sum - ar[i] >= 0)
    {

        // Dizideki her eleman
        // toplamına katkıda bulunabilecek  
        r.push_back(ar[i]); // elamanları listeye ekle

        // recursive:özyinelemeli mantık fonksiyonun içinde koşuldan sonra tekrar fonksiyonu çağır.
        findNumbers(ar, sum - ar[i], res, r, i);
        i++;

        //listeden elamanları çıkar
        r.pop_back();
    }
}


// verilmiş olan  toplam değerine tüm  liste  kombinasyonlarını döndüren veri yapısı
// 
vector<vector<int>> combinationSum(vector<int>& ar,
    int sum)
{
    // listeyi sırala
    sort(ar.begin(), ar.end());

    // aynı elamanları indexten sil 
    ar.erase(unique(ar.begin(), ar.end()), ar.end());

    vector<int> r;
    vector<vector<int>> res;
    findNumbers(ar, sum, res, r, 0);

    return res;
}

// Driver code 
int main()
{
    vector<int> ar;
    ar.push_back(2);
    ar.push_back(4);
    ar.push_back(6);
    ar.push_back(8);
    int n = ar.size();

    int sum = 8; // verilen toplam değeri
    vector<vector<int>> res = combinationSum(ar, sum);

    // liste boş ise
    if (res.size() == 0)
    {
        cout << "Emptyn";
        return 0;
    }

    // Sonuçta saklanan tüm kombinasyonları ekrana yazdır
    for (int i = 0; i < res.size(); i++)
    {
        if (res[i].size() > 0)
        {
            cout << " ( ";
            for (int j = 0; j < res[i].size(); j++)
                cout << res[i][j] << " ";
            cout << ")";
        }
    }
}
}