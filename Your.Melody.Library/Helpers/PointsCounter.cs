using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Your.Melody.Library.Models;

namespace Your.Melody.Library.Helpers
{
    public class PointsCounter : IPointsCounter
    {
        public async Task<float> CountingPointsAsync(Song song, string titleByUser, string artistByUser, float secWhenUserResponce)
        {
            //Max 100 pts.
            float result = 0;
            result += 50 * (await textEquality(titleByUser, song.Title));
            result += 50 * (await textEquality(artistByUser, song.Artist));
            result /= 1 + (secWhenUserResponce / 15);
            return result;
        }
        private async Task<float> textEquality(string a, string b)
        {
            a = await normalizingString(a);
            b = await normalizingString(b);
            if (a == b)
                return 1;
            if ((a.Length == 0) || (b.Length == 0))
            {
                return 0;
            }
            float maxLen = a.Length > b.Length ? a.Length : b.Length;
            int minLen = a.Length < b.Length ? a.Length : b.Length;
            int sameCharAtIndex = 0;
            for (int i = 0; i < minLen; i++)
            {
                if (a[i] == b[i])
                {
                    sameCharAtIndex++;
                }
            }
            return sameCharAtIndex / maxLen;
        }
        private async Task<string> normalizingString(string text) => text.ToLower().Trim().Replace(" ", "");
    }
}
