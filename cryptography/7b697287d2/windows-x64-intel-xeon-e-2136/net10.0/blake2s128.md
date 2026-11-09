| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |         82.39 ns |       1.230 ns |       1.150 ns |   2,975 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |         89.68 ns |       1.036 ns |       0.969 ns |   2,953 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         96.42 ns |       1.490 ns |       1.394 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        108.01 ns |       1.538 ns |       1.439 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |        119.30 ns |       2.174 ns |       2.034 ns |   6,642 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         75.10 ns |       0.979 ns |       0.916 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |         86.99 ns |       0.615 ns |       0.575 ns |   2,958 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         95.47 ns |       1.400 ns |       1.310 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        105.46 ns |       1.572 ns |       1.470 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |        116.85 ns |       2.230 ns |       2.086 ns |   6,639 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        152.44 ns |       2.251 ns |       2.105 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        173.48 ns |       2.975 ns |       2.783 ns |   5,383 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        175.43 ns |       2.430 ns |       2.273 ns |   2,953 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        184.73 ns |       2.787 ns |       2.607 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        231.98 ns |       3.465 ns |       3.241 ns |   6,651 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        146.87 ns |       1.124 ns |       1.052 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        166.84 ns |       3.101 ns |       2.900 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        172.23 ns |       2.435 ns |       2.277 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        183.11 ns |       2.691 ns |       2.517 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        229.23 ns |       2.649 ns |       2.478 ns |   6,661 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        221.31 ns |       3.130 ns |       2.928 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        244.51 ns |       3.716 ns |       3.476 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        256.60 ns |       4.049 ns |       3.787 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        260.29 ns |       4.755 ns |       4.448 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        342.95 ns |       4.540 ns |       4.247 ns |   6,639 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,090.59 ns |       2.319 ns |       2.056 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,240.80 ns |       2.411 ns |       2.137 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,260.56 ns |      18.615 ns |      17.413 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,324.51 ns |      23.393 ns |      21.882 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,758.42 ns |       2.005 ns |       1.875 ns |   6,657 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,262.23 ns |      18.160 ns |      16.987 ns |   2,965 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,298.58 ns |      21.809 ns |      20.400 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,366.46 ns |      12.895 ns |      12.062 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,421.69 ns |      22.902 ns |      21.423 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,922.96 ns |      32.759 ns |      30.643 ns |   6,639 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |      8,889.07 ns |     131.594 ns |     123.093 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |      9,346.49 ns |     111.312 ns |     104.122 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     10,066.58 ns |     140.545 ns |     131.466 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |     10,341.39 ns |      84.776 ns |      79.299 ns |   2,973 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     14,179.03 ns |     169.840 ns |     158.869 ns |   6,899 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     72,517.85 ns |   1,121.068 ns |   1,048.648 ns |   3,223 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     73,895.57 ns |   1,355.746 ns |   1,268.165 ns |   5,651 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     80,654.64 ns |   1,124.133 ns |   1,051.515 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |     82,720.08 ns |   1,358.003 ns |   1,270.277 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |    112,223.70 ns |   1,591.861 ns |   1,489.028 ns |   6,899 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    142,726.17 ns |   2,100.827 ns |   1,965.115 ns |   3,223 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    148,309.23 ns |   2,278.506 ns |   2,131.316 ns |   5,651 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    160,286.71 ns |   2,501.412 ns |   2,339.822 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    164,282.06 ns |   2,363.227 ns |   2,210.564 ns |   3,210 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    225,738.30 ns |   2,814.351 ns |   2,632.546 ns |   6,899 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,082,608.85 ns |  18,491.137 ns |  17,296.621 ns |   3,230 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,134,300.70 ns |  14,447.596 ns |  13,514.290 ns |   5,657 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,227,367.77 ns |  17,937.986 ns |  16,779.203 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,256,079.02 ns |  16,594.832 ns |  14,710.886 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,733,140.65 ns |  13,074.951 ns |  12,230.317 ns |   6,909 B |         - |
|                                                   |              |                  |                |                |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 10,985,992.40 ns | 151,548.143 ns | 141,758.227 ns |   3,230 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 11,416,807.92 ns | 183,978.702 ns | 172,093.793 ns |   5,659 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 12,373,658.85 ns | 200,356.623 ns | 187,413.709 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 12,640,897.08 ns | 217,152.605 ns | 203,124.682 ns |   3,218 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 17,511,931.46 ns | 173,761.562 ns | 162,536.673 ns |   6,898 B |         - |