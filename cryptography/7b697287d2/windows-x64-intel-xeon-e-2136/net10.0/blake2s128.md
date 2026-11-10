| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |        104.20 ns |      0.068 ns |      0.060 ns |   2,997 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |        117.27 ns |      0.315 ns |      0.295 ns |   2,953 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |        126.72 ns |      0.162 ns |      0.144 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        144.70 ns |      0.077 ns |      0.064 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |        158.33 ns |      0.203 ns |      0.190 ns |   6,641 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         98.50 ns |      0.073 ns |      0.064 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |        113.90 ns |      0.084 ns |      0.079 ns |   2,958 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |        124.96 ns |      0.166 ns |      0.155 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        141.72 ns |      0.210 ns |      0.196 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |        153.52 ns |      0.237 ns |      0.222 ns |   6,637 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        200.24 ns |      0.162 ns |      0.151 ns |   2,980 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        226.34 ns |      0.093 ns |      0.087 ns |   5,383 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        231.90 ns |      0.104 ns |      0.092 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        245.57 ns |      0.354 ns |      0.314 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        305.33 ns |      0.288 ns |      0.256 ns |   6,639 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        191.34 ns |      0.138 ns |      0.122 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        220.29 ns |      0.144 ns |      0.134 ns |   2,979 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        224.81 ns |      0.145 ns |      0.128 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        242.45 ns |      0.218 ns |      0.193 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        299.74 ns |      0.531 ns |      0.497 ns |   6,664 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        291.26 ns |      0.286 ns |      0.253 ns |   2,963 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        321.56 ns |      0.215 ns |      0.201 ns |   5,383 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        334.69 ns |      0.416 ns |      0.368 ns |   2,952 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        344.22 ns |      0.204 ns |      0.181 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        450.06 ns |      0.677 ns |      0.633 ns |   6,639 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,462.40 ns |      1.075 ns |      0.898 ns |   2,985 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,631.79 ns |      0.687 ns |      0.643 ns |   5,402 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,679.64 ns |      0.794 ns |      0.743 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,752.00 ns |      1.486 ns |      1.390 ns |   2,969 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      2,370.47 ns |      2.132 ns |      1.994 ns |   6,913 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,631.75 ns |      1.042 ns |      0.923 ns |   2,979 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,695.56 ns |      1.015 ns |      0.949 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,797.65 ns |      0.856 ns |      0.759 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,854.57 ns |      1.214 ns |      1.077 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      2,520.23 ns |      2.504 ns |      2.220 ns |   6,639 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |     11,640.91 ns |     14.379 ns |     12.007 ns |   3,237 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     12,245.51 ns |      8.243 ns |      7.710 ns |   5,652 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     13,236.85 ns |      5.521 ns |      5.164 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |     13,456.83 ns |     13.255 ns |     12.399 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     18,501.57 ns |     17.805 ns |     16.654 ns |   6,899 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     94,463.10 ns |    142.858 ns |    133.630 ns |   3,223 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     97,410.26 ns |     52.612 ns |     49.214 ns |   5,651 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |    105,424.16 ns |    117.852 ns |     98.412 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |    108,940.84 ns |    128.534 ns |    120.231 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |    147,339.67 ns |    142.952 ns |    126.723 ns |   6,899 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    186,439.62 ns |    150.520 ns |    117.516 ns |   3,223 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    194,752.39 ns |     72.201 ns |     64.005 ns |   5,651 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    211,050.73 ns |    202.262 ns |    189.196 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    215,564.00 ns |    100.910 ns |     89.454 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    295,798.60 ns |    186.750 ns |    165.549 ns |   6,899 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,425,720.94 ns |  1,271.032 ns |  1,126.737 ns |   3,237 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,486,464.54 ns |    771.783 ns |    721.927 ns |   5,656 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,610,475.13 ns |  1,493.800 ns |  1,324.215 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,645,633.17 ns |    685.844 ns |    572.711 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  2,255,728.10 ns |  5,485.665 ns |  5,131.294 ns |   6,899 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 14,409,787.61 ns |  5,235.067 ns |  4,640.750 ns |   3,229 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 14,999,189.69 ns | 37,899.497 ns | 35,451.213 ns |   5,658 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 16,259,905.77 ns |  8,867.911 ns |  7,405.107 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 16,690,978.57 ns | 23,540.507 ns | 20,868.046 ns |   3,210 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 22,694,854.91 ns | 27,581.804 ns | 24,450.551 ns |   6,898 B |         - |