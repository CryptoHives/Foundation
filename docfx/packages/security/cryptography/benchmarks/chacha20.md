| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      70.30 ns |     0.391 ns |     0.366 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     127.50 ns |     0.391 ns |     0.347 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     279.67 ns |     1.510 ns |     1.412 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     315.29 ns |     1.604 ns |     1.500 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     458.14 ns |     1.539 ns |     1.285 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      71.31 ns |     0.361 ns |     0.338 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     127.66 ns |     0.489 ns |     0.433 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     277.97 ns |     1.391 ns |     1.301 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     311.40 ns |     1.293 ns |     1.210 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     456.78 ns |     0.792 ns |     0.702 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     524.81 ns |     1.154 ns |     0.963 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |     998.54 ns |     3.417 ns |     3.029 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,507.12 ns |     4.955 ns |     4.392 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,783.62 ns |     4.632 ns |     3.616 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,560.45 ns |    10.715 ns |    10.023 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     525.61 ns |     1.458 ns |     1.293 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |     998.76 ns |     2.581 ns |     2.414 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,507.80 ns |     3.303 ns |     2.758 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,785.33 ns |     3.702 ns |     3.092 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,558.89 ns |     8.950 ns |     8.372 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,115.33 ns |    17.230 ns |    16.117 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,997.62 ns |    33.518 ns |    31.353 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,261.88 ns |    35.639 ns |    33.337 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,512.36 ns |    31.471 ns |    29.438 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,339.18 ns |    72.562 ns |    64.324 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,121.69 ns |    12.509 ns |    10.446 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   7,993.67 ns |    22.895 ns |    21.416 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,271.06 ns |    38.458 ns |    35.974 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,494.19 ns |    41.555 ns |    36.837 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,312.80 ns |   100.734 ns |    94.227 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  66,347.62 ns | 1,153.625 ns |   963.329 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,767.59 ns |   291.144 ns |   258.092 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 180,563.04 ns | 1,292.254 ns | 1,208.775 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 215,409.05 ns |   844.844 ns |   705.483 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 454,371.10 ns | 1,267.200 ns | 1,185.340 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  65,958.63 ns |   370.215 ns |   309.146 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,851.93 ns |   519.122 ns |   485.587 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 181,251.55 ns |   867.914 ns |   811.847 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,888.60 ns |   565.588 ns |   501.379 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 452,005.59 ns | 1,889.083 ns | 1,767.050 ns |         - |