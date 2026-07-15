| Description                                  | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|--------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3Native       | 128B         |        98.72 ns |     0.354 ns |     0.314 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 128B         |       151.65 ns |     0.698 ns |     0.619 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |       605.64 ns |     0.999 ns |     0.934 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |     1,324.48 ns |     1.579 ns |     1.399 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 137B         |       151.14 ns |     0.384 ns |     0.359 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 137B         |       221.85 ns |     0.687 ns |     0.609 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |       896.73 ns |     1.727 ns |     1.442 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |     1,955.48 ns |     2.243 ns |     1.989 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1KB          |       751.90 ns |     2.216 ns |     1.964 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     1,079.61 ns |     5.134 ns |     4.803 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |     4,653.88 ns |     7.172 ns |     5.989 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |     9,787.01 ns |    12.516 ns |    11.095 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1025B        |       854.86 ns |     2.837 ns |     2.369 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 1025B        |     1,218.46 ns |     3.006 ns |     2.812 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |     5,283.08 ns |    11.403 ns |    10.666 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |    10,950.92 ns |    20.636 ns |    19.303 ns |      56 B |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 8KB          |     1,179.97 ns |     5.033 ns |     4.462 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9,886.09 ns |    38.619 ns |    34.235 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |    39,429.63 ns |    32.664 ns |    25.502 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |    81,772.12 ns |   135.506 ns |   126.752 ns |     392 B |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 128KB        |    14,404.36 ns |    28.715 ns |    26.860 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   165,982.31 ns |   547.065 ns |   511.725 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |   632,613.36 ns | 1,566.750 ns | 1,388.883 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        | 1,329,108.01 ns | 1,471.570 ns | 1,148.905 ns |    7112 B |