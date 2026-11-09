| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |         79.40 ns |       1.475 ns |       1.380 ns |   2,995 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |         92.53 ns |       1.302 ns |       1.218 ns |   2,980 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         95.88 ns |       1.480 ns |       1.385 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        113.05 ns |       1.395 ns |       1.305 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |        120.54 ns |       1.842 ns |       1.723 ns |   6,645 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         75.42 ns |       0.641 ns |       0.600 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |         85.93 ns |       1.571 ns |       1.469 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         94.43 ns |       1.279 ns |       1.197 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        110.65 ns |       1.649 ns |       1.543 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |        117.27 ns |       1.857 ns |       1.737 ns |   6,639 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        155.87 ns |       2.826 ns |       2.643 ns |   2,967 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        172.05 ns |       2.712 ns |       2.537 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        174.80 ns |       2.818 ns |       2.636 ns |   2,955 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        188.18 ns |       2.990 ns |       2.797 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        234.59 ns |       3.956 ns |       3.700 ns |   6,644 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        144.94 ns |       2.340 ns |       2.189 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        167.45 ns |       2.244 ns |       2.099 ns |   2,978 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        171.17 ns |       2.834 ns |       2.651 ns |   5,405 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        189.01 ns |       2.481 ns |       2.321 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        228.90 ns |       3.037 ns |       2.841 ns |   6,663 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        221.30 ns |       3.284 ns |       3.072 ns |   2,984 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        244.84 ns |       3.778 ns |       3.534 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        255.24 ns |       3.628 ns |       3.394 ns |   2,969 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        267.15 ns |       3.941 ns |       3.686 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        343.49 ns |       5.539 ns |       5.181 ns |   6,643 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,110.78 ns |      17.630 ns |      16.492 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,262.60 ns |      17.954 ns |      16.794 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,297.15 ns |      17.790 ns |      16.641 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,333.13 ns |      19.892 ns |      18.607 ns |   2,978 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,811.20 ns |      22.523 ns |      21.068 ns |   6,652 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,264.52 ns |      13.142 ns |      12.293 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,308.03 ns |       8.689 ns |       8.128 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,354.98 ns |      22.089 ns |      20.662 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,427.11 ns |       7.272 ns |       6.802 ns |   2,956 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,931.10 ns |      15.997 ns |      14.964 ns |   6,654 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |      8,926.86 ns |      95.614 ns |      89.437 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |      9,059.71 ns |      21.011 ns |      18.626 ns |   5,405 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     10,062.25 ns |     183.028 ns |     171.204 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |     10,280.09 ns |     156.892 ns |     139.081 ns |   3,227 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     14,102.40 ns |     205.500 ns |     192.225 ns |   6,662 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     72,417.40 ns |     881.639 ns |     824.686 ns |   3,225 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     74,419.40 ns |     863.266 ns |     807.499 ns |   5,653 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     81,445.01 ns |   1,048.539 ns |     980.804 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |     83,530.40 ns |     754.895 ns |     706.129 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |    113,338.48 ns |   1,388.599 ns |   1,298.896 ns |   6,901 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    142,571.74 ns |   2,256.667 ns |   2,110.888 ns |   3,225 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    149,113.21 ns |   1,802.575 ns |   1,686.129 ns |   5,653 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    161,624.07 ns |   1,599.897 ns |   1,418.267 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    164,402.41 ns |   1,928.765 ns |   1,804.168 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    226,078.01 ns |   2,197.161 ns |   2,055.226 ns |   6,901 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,089,002.83 ns |  13,843.209 ns |  12,948.947 ns |   3,239 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,135,422.70 ns |  13,244.958 ns |  12,389.342 ns |   5,659 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,232,670.30 ns |  14,810.919 ns |  13,129.494 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,262,420.77 ns |  15,070.122 ns |  14,096.601 ns |   3,220 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,737,330.65 ns |  22,110.959 ns |  20,682.605 ns |   6,908 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 11,459,846.04 ns | 137,358.478 ns | 128,485.206 ns |   5,661 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 11,554,482.71 ns | 124,138.880 ns | 116,119.586 ns |   3,234 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 12,450,559.69 ns | 125,079.116 ns | 116,999.083 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 12,752,182.92 ns | 147,611.730 ns | 138,076.104 ns |   3,245 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 17,436,662.50 ns |  93,967.455 ns |  87,897.216 ns |   6,926 B |         - |