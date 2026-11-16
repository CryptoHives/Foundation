| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Median           | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |         76.62 ns |      0.051 ns |      0.042 ns |         76.62 ns |   2,852 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |         80.04 ns |      0.039 ns |      0.033 ns |         80.04 ns |   2,949 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         95.69 ns |      1.158 ns |      1.239 ns |         95.30 ns |   6,604 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         96.25 ns |      1.945 ns |      4.622 ns |         93.90 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        104.36 ns |      2.080 ns |      2.396 ns |        104.46 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         78.11 ns |      0.324 ns |      0.303 ns |         77.95 ns |   2,862 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |         88.34 ns |      0.191 ns |      0.179 ns |         88.39 ns |   2,950 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         92.55 ns |      0.280 ns |      0.344 ns |         92.44 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        123.30 ns |      0.435 ns |      0.407 ns |        123.33 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |        144.50 ns |      1.302 ns |      1.218 ns |        145.13 ns |   6,614 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        158.42 ns |      3.144 ns |      3.621 ns |        159.97 ns |   2,849 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        168.84 ns |      2.297 ns |      2.149 ns |        169.65 ns |   2,940 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        172.38 ns |      0.088 ns |      0.078 ns |        172.37 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        181.98 ns |      0.075 ns |      0.066 ns |        181.95 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        207.67 ns |      9.656 ns |     28.470 ns |        183.87 ns |   6,616 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        150.22 ns |      0.043 ns |      0.036 ns |        150.22 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        157.17 ns |      0.174 ns |      0.154 ns |        157.07 ns |   2,954 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        171.60 ns |      0.180 ns |      0.160 ns |        171.55 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        179.82 ns |      0.466 ns |      0.413 ns |        179.70 ns |   6,618 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        182.16 ns |      0.102 ns |      0.091 ns |        182.13 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        227.18 ns |      0.121 ns |      0.107 ns |        227.15 ns |   2,863 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        236.66 ns |      0.055 ns |      0.046 ns |        236.66 ns |   2,937 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        251.67 ns |      0.134 ns |      0.125 ns |        251.63 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        265.52 ns |      0.175 ns |      0.164 ns |        265.48 ns |   6,330 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        267.57 ns |      0.657 ns |      0.615 ns |        267.34 ns |   6,601 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,183.51 ns |      0.418 ns |      0.349 ns |      1,183.46 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,223.65 ns |      0.353 ns |      0.331 ns |      1,223.57 ns |   2,954 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,267.04 ns |      1.604 ns |      1.422 ns |      1,267.54 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,355.11 ns |      0.823 ns |      0.770 ns |      1,354.79 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,406.32 ns |      2.694 ns |      2.103 ns |      1,405.29 ns |   6,622 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,257.32 ns |      9.401 ns |      8.793 ns |      1,260.45 ns |   2,863 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,311.29 ns |      0.493 ns |      0.462 ns |      1,311.17 ns |   2,944 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,352.22 ns |      0.657 ns |      0.614 ns |      1,352.18 ns |   5,855 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,442.76 ns |      1.887 ns |      1.673 ns |      1,443.18 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,478.91 ns |      1.884 ns |      1.574 ns |      1,478.60 ns |   6,602 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |      9,451.28 ns |      3.302 ns |      3.089 ns |      9,450.40 ns |   2,866 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |      9,750.04 ns |     28.714 ns |     26.859 ns |      9,757.54 ns |   2,954 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     10,018.43 ns |      6.731 ns |      6.296 ns |     10,018.87 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     10,716.37 ns |      3.773 ns |      3.529 ns |     10,716.31 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     11,180.76 ns |     25.680 ns |     22.764 ns |     11,176.26 ns |   6,861 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     75,470.83 ns |     27.871 ns |     26.071 ns |     75,466.28 ns |   3,119 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |     78,070.74 ns |     72.513 ns |     67.829 ns |     78,091.47 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     80,052.73 ns |     39.124 ns |     36.597 ns |     80,042.42 ns |   6,125 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     85,705.42 ns |     18.226 ns |     16.157 ns |     85,701.88 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     88,353.71 ns |    124.797 ns |    104.211 ns |     88,328.81 ns |   6,871 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    151,207.20 ns |    149.881 ns |    132.865 ns |    151,191.52 ns |   3,109 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    156,229.38 ns |    187.226 ns |    175.131 ns |    156,252.98 ns |   3,197 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    160,022.59 ns |    101.845 ns |     95.266 ns |    160,031.08 ns |   6,125 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    171,347.04 ns |     91.504 ns |     81.116 ns |    171,343.13 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    178,217.83 ns |  1,024.923 ns |    958.714 ns |    178,309.35 ns |   6,861 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,154,484.86 ns |    460.210 ns |    384.296 ns |  1,154,377.93 ns |   3,109 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,192,390.44 ns |    433.627 ns |    405.615 ns |  1,192,483.20 ns |   3,197 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,221,357.34 ns |    530.248 ns |    495.994 ns |  1,221,462.11 ns |   6,131 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,304,684.35 ns |    450.776 ns |    421.656 ns |  1,304,719.14 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,359,178.74 ns |  3,279.040 ns |  2,738.147 ns |  1,358,141.41 ns |   6,868 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 11,522,799.44 ns |  4,769.803 ns |  4,228.306 ns | 11,522,971.09 ns |   3,116 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 11,932,386.35 ns | 13,513.059 ns | 12,640.124 ns | 11,934,053.12 ns |   3,204 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 12,224,363.96 ns |  2,691.129 ns |  2,517.283 ns | 12,223,465.62 ns |   6,130 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 13,113,527.50 ns | 10,946.891 ns | 10,239.729 ns | 13,112,654.69 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 13,657,523.96 ns | 26,730.418 ns | 20,869.352 ns | 13,658,282.81 ns |   6,867 B |         - |