| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      68.42 ns |     0.269 ns |     0.239 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     125.87 ns |     0.635 ns |     0.594 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     279.30 ns |     1.100 ns |     1.029 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     311.04 ns |     1.392 ns |     1.234 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     458.01 ns |     1.897 ns |     1.584 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      68.53 ns |     0.316 ns |     0.296 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     125.66 ns |     0.524 ns |     0.491 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     278.75 ns |     0.899 ns |     0.797 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     311.64 ns |     1.129 ns |     1.000 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     456.57 ns |     1.012 ns |     0.845 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     518.23 ns |     1.185 ns |     1.109 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |     997.19 ns |     2.319 ns |     2.169 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,498.94 ns |     4.664 ns |     4.134 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,787.23 ns |     7.290 ns |     6.463 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,560.91 ns |    10.767 ns |    10.072 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     518.37 ns |     0.907 ns |     0.804 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |     996.06 ns |     2.425 ns |     2.150 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,516.59 ns |     3.281 ns |     2.909 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,782.23 ns |     6.645 ns |     5.890 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,563.68 ns |    12.874 ns |    12.042 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,122.81 ns |    14.107 ns |    13.196 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,971.87 ns |    26.509 ns |    24.797 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,347.33 ns |    14.507 ns |    12.860 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,501.08 ns |    64.908 ns |    54.201 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,393.62 ns |    61.938 ns |    54.907 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,116.31 ns |    11.433 ns |    10.694 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   7,966.68 ns |    20.372 ns |    18.059 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,264.74 ns |    26.551 ns |    23.536 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,499.39 ns |    53.415 ns |    47.351 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,398.83 ns |   110.986 ns |    98.387 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  65,942.64 ns |   243.524 ns |   227.792 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,475.10 ns |   476.397 ns |   445.622 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 180,261.59 ns |   521.738 ns |   488.034 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,979.71 ns | 1,163.643 ns | 1,031.540 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 454,008.29 ns | 1,464.315 ns | 1,298.077 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  65,793.07 ns |   158.267 ns |   148.043 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,433.25 ns |   585.925 ns |   519.408 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 183,684.96 ns |   513.624 ns |   455.315 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,419.99 ns |   734.938 ns |   613.706 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 453,073.36 ns | 1,177.365 ns | 1,101.308 ns |         - |