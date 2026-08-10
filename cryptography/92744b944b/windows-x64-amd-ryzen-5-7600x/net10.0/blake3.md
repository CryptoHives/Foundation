| Description                                  | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|--------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3Native       | 128B         |        98.61 ns |     0.855 ns |     0.758 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 128B         |       148.60 ns |     0.734 ns |     0.650 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |       587.56 ns |     1.361 ns |     1.273 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |     1,285.48 ns |     2.560 ns |     2.395 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 137B         |       149.40 ns |     0.445 ns |     0.416 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 137B         |       218.56 ns |     0.574 ns |     0.479 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |       868.48 ns |     2.480 ns |     2.320 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |     1,904.40 ns |     5.509 ns |     5.153 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1KB          |       742.57 ns |     1.691 ns |     1.412 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     1,060.64 ns |     2.892 ns |     2.705 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |     4,526.54 ns |    17.652 ns |    16.512 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |     9,566.15 ns |    24.563 ns |    22.976 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1025B        |       848.22 ns |     1.238 ns |     1.097 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 1025B        |     1,221.44 ns |     3.884 ns |     3.633 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |     5,112.20 ns |     9.463 ns |     8.852 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |    10,785.00 ns |    22.956 ns |    21.473 ns |      56 B |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 8KB          |     1,157.22 ns |     4.674 ns |     4.372 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 8KB          |    10,261.63 ns |    86.687 ns |    81.087 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |    38,159.58 ns |    89.667 ns |    83.874 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |    79,464.11 ns |   272.869 ns |   255.242 ns |     392 B |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 128KB        |    14,185.28 ns |    26.225 ns |    23.248 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   166,110.51 ns |   838.205 ns |   784.057 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |   616,523.33 ns | 1,480.328 ns | 1,312.272 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        | 1,304,976.51 ns | 3,011.859 ns | 2,669.935 ns |    7112 B |