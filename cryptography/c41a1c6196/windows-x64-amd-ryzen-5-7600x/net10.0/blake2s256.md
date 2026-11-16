| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Median           | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |         76.18 ns |      0.045 ns |      0.040 ns |         76.18 ns |   2,863 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |         80.79 ns |      0.058 ns |      0.051 ns |         80.78 ns |   2,977 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         93.81 ns |      0.273 ns |      0.228 ns |         93.71 ns |   6,608 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         96.36 ns |      0.080 ns |      0.075 ns |         96.36 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        101.94 ns |      0.226 ns |      0.211 ns |        101.91 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         78.21 ns |      0.062 ns |      0.058 ns |         78.20 ns |   2,871 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |         80.62 ns |      0.112 ns |      0.099 ns |         80.66 ns |   2,959 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         94.11 ns |      0.335 ns |      0.313 ns |         94.15 ns |   5,883 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         94.42 ns |      0.179 ns |      0.140 ns |         94.46 ns |   6,616 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        101.06 ns |      0.125 ns |      0.104 ns |        101.05 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        154.67 ns |      0.186 ns |      0.155 ns |        154.67 ns |   2,854 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        161.96 ns |      0.071 ns |      0.063 ns |        161.96 ns |   2,941 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        173.13 ns |      0.170 ns |      0.151 ns |        173.10 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        183.53 ns |      0.300 ns |      0.266 ns |        183.52 ns |   6,605 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        184.89 ns |      0.164 ns |      0.153 ns |        184.90 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        150.60 ns |      0.102 ns |      0.091 ns |        150.58 ns |   2,868 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        156.43 ns |      0.212 ns |      0.198 ns |        156.39 ns |   2,956 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        174.18 ns |      0.548 ns |      0.513 ns |        174.13 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        185.90 ns |      0.203 ns |      0.180 ns |        185.90 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        191.70 ns |      4.963 ns |     14.555 ns |        182.81 ns |   6,620 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        229.56 ns |      0.860 ns |      0.804 ns |        229.61 ns |   2,853 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        237.54 ns |      0.235 ns |      0.220 ns |        237.54 ns |   2,941 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        252.67 ns |      0.128 ns |      0.113 ns |        252.68 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        266.99 ns |      1.277 ns |      1.132 ns |        266.54 ns |   6,605 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        269.14 ns |      0.382 ns |      0.357 ns |        269.01 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,187.73 ns |      0.543 ns |      0.508 ns |      1,187.93 ns |   3,111 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,227.50 ns |      1.163 ns |      1.087 ns |      1,227.76 ns |   2,956 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,271.77 ns |      2.200 ns |      2.058 ns |      1,272.59 ns |   6,128 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,365.68 ns |      0.822 ns |      0.769 ns |      1,365.57 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,393.80 ns |      6.880 ns |      6.099 ns |      1,393.80 ns |   6,620 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,266.93 ns |      0.596 ns |      0.557 ns |      1,266.95 ns |   2,867 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,306.14 ns |      0.609 ns |      0.570 ns |      1,306.13 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,346.41 ns |      0.610 ns |      0.570 ns |      1,346.42 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,447.29 ns |      0.681 ns |      0.569 ns |      1,447.17 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,490.41 ns |      2.951 ns |      2.616 ns |      1,490.05 ns |   6,623 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |      9,498.01 ns |      4.000 ns |      3.340 ns |      9,499.02 ns |   2,868 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |      9,801.31 ns |      9.870 ns |      9.232 ns |      9,802.83 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     10,027.93 ns |     11.866 ns |     11.099 ns |     10,029.36 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     10,804.27 ns |      6.206 ns |      5.805 ns |     10,805.38 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     11,649.43 ns |     44.808 ns |     39.721 ns |     11,643.89 ns |   6,620 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     75,939.29 ns |     53.688 ns |     50.220 ns |     75,930.09 ns |   3,111 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |     78,091.01 ns |     91.763 ns |     85.835 ns |     78,110.30 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     80,276.68 ns |     38.234 ns |     33.894 ns |     80,265.00 ns |   6,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     85,559.42 ns |     32.419 ns |     28.739 ns |     85,555.15 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     88,545.84 ns |    262.286 ns |    219.021 ns |     88,559.02 ns |   6,863 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    151,214.88 ns |     71.530 ns |     63.409 ns |    151,223.41 ns |   3,111 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    156,197.95 ns |    159.519 ns |    133.206 ns |    156,220.24 ns |   3,199 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    160,034.57 ns |     92.358 ns |     86.391 ns |    160,053.22 ns |   6,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    171,405.01 ns |     39.350 ns |     34.883 ns |    171,403.85 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    177,435.13 ns |    621.733 ns |    551.150 ns |    177,156.64 ns |   6,873 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,154,932.81 ns |  1,378.902 ns |  1,289.826 ns |  1,155,360.94 ns |   3,118 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,196,201.86 ns |    795.505 ns |    744.116 ns |  1,196,152.34 ns |   3,206 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,227,032.23 ns |    862.459 ns |    764.547 ns |  1,226,738.38 ns |   6,133 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,317,309.71 ns |  1,254.872 ns |  1,112.412 ns |  1,317,438.38 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,374,546.86 ns |  5,441.647 ns |  5,090.120 ns |  1,372,965.04 ns |   6,870 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 11,540,597.81 ns |  7,871.678 ns |  7,363.173 ns | 11,540,089.06 ns |   3,118 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 11,970,173.21 ns | 14,884.993 ns | 13,195.159 ns | 11,975,089.06 ns |   3,206 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 12,230,683.37 ns | 12,150.148 ns | 10,770.790 ns | 12,234,454.69 ns |   6,132 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 13,085,748.88 ns |  8,490.099 ns |  7,526.251 ns | 13,085,994.53 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 13,765,438.06 ns | 30,489.271 ns | 27,027.945 ns | 13,764,971.09 ns |   6,892 B |         - |