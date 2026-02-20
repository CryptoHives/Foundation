| Description                       | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      70.04 ns |     0.260 ns |   0.243 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     135.98 ns |     1.083 ns |   0.905 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     278.01 ns |     0.643 ns |   0.602 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     314.48 ns |     0.691 ns |   0.577 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     457.75 ns |     0.448 ns |   0.419 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      70.08 ns |     0.184 ns |   0.172 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     127.79 ns |     0.620 ns |   0.484 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     275.93 ns |     0.641 ns |   0.600 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     312.23 ns |     0.470 ns |   0.417 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     455.58 ns |     0.595 ns |   0.557 ns |         - |
|                                   |              |               |              |            |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     519.13 ns |     0.836 ns |   0.782 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |   1,001.75 ns |     2.699 ns |   2.392 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,491.32 ns |     2.797 ns |   2.184 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,786.91 ns |     2.542 ns |   2.254 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,568.57 ns |    22.705 ns |  18.959 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     521.27 ns |     1.998 ns |   1.869 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |   1,001.71 ns |     3.462 ns |   3.239 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,493.09 ns |     3.188 ns |   2.982 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,785.02 ns |     2.386 ns |   2.115 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,555.04 ns |     2.952 ns |   2.617 ns |         - |
|                                   |              |               |              |            |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,135.21 ns |    20.508 ns |  18.180 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,980.00 ns |    17.992 ns |  15.024 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,197.21 ns |    17.520 ns |  16.388 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,518.53 ns |    14.068 ns |  11.747 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,316.47 ns |    37.963 ns |  35.511 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,138.78 ns |    14.515 ns |  13.577 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   8,006.97 ns |    40.998 ns |  38.349 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,192.73 ns |    33.263 ns |  31.115 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,541.02 ns |    43.845 ns |  36.613 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,372.13 ns |    33.827 ns |  28.247 ns |         - |
|                                   |              |               |              |            |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  66,391.86 ns | 1,162.005 ns | 970.327 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,684.27 ns |   345.867 ns | 306.602 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 177,474.64 ns |   190.713 ns | 169.062 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 215,357.43 ns |   271.654 ns | 254.105 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 454,620.02 ns |   873.215 ns | 816.806 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  66,130.17 ns |   166.340 ns | 155.595 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 128,037.61 ns |   633.890 ns | 561.927 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 179,022.34 ns |   410.726 ns | 364.098 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 215,398.45 ns |   306.743 ns | 286.927 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 452,128.60 ns |   561.345 ns | 497.617 ns |         - |