| Description                             | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      86.89 ns |   0.054 ns |   0.051 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     142.04 ns |   1.055 ns |   0.936 ns |   2,396 B |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     270.37 ns |   0.877 ns |   0.777 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     323.63 ns |   0.313 ns |   0.261 ns |   7,343 B |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     550.02 ns |   0.718 ns |   0.636 ns |   3,582 B |         - |
|                                         |              |               |            |            |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      76.26 ns |   0.183 ns |   0.162 ns |   2,658 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     142.02 ns |   0.278 ns |   0.260 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     288.40 ns |   1.652 ns |   1.545 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     328.02 ns |   0.607 ns |   0.568 ns |   7,343 B |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     564.16 ns |   1.471 ns |   1.376 ns |   3,603 B |         - |
|                                         |              |               |            |            |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     577.51 ns |   0.383 ns |   0.340 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,111.27 ns |   0.798 ns |   0.747 ns |   2,396 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,764.22 ns |   3.199 ns |   2.993 ns |   7,429 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,001.73 ns |   6.832 ns |   6.391 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,239.58 ns |   6.365 ns |   5.315 ns |   3,582 B |         - |
|                                         |              |               |            |            |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     577.69 ns |   0.482 ns |   0.451 ns |   2,637 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,110.15 ns |   0.961 ns |   0.899 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,796.49 ns |   2.367 ns |   2.215 ns |   7,435 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,003.03 ns |   5.765 ns |   5.111 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,268.63 ns |  11.182 ns |   9.913 ns |   3,582 B |         - |
|                                         |              |               |            |            |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,616.09 ns |   3.565 ns |   3.334 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,870.36 ns |   5.417 ns |   4.802 ns |   2,388 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,314.76 ns |  27.089 ns |  22.620 ns |   7,437 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  15,783.03 ns |  37.930 ns |  33.624 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  33,844.34 ns |  53.722 ns |  44.861 ns |   3,603 B |         - |
|                                         |              |               |            |            |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,616.81 ns |   2.747 ns |   2.570 ns |   2,671 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,882.79 ns |   7.158 ns |   6.696 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,225.77 ns |  17.130 ns |  16.023 ns |   7,434 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  15,801.16 ns |  30.647 ns |  27.168 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  33,800.87 ns |  70.163 ns |  62.197 ns |   3,582 B |         - |
|                                         |              |               |            |            |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,775.30 ns |  44.456 ns |  41.584 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,960.15 ns | 113.286 ns | 105.967 ns |   2,388 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 209,716.60 ns | 219.406 ns | 183.214 ns |   7,449 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 252,440.80 ns | 636.094 ns | 595.002 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 539,929.97 ns | 995.430 ns | 931.125 ns |   3,582 B |         - |
|                                         |              |               |            |            |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,808.23 ns |  41.101 ns |  38.446 ns |   2,637 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,937.28 ns | 111.425 ns | 104.227 ns |   2,409 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 209,304.58 ns | 202.194 ns | 179.240 ns |   7,449 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 252,453.49 ns | 600.332 ns | 561.551 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 539,664.05 ns | 646.713 ns | 504.911 ns |   3,603 B |         - |