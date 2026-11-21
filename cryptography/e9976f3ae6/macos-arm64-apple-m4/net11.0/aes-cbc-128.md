| Description                                 | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.70 ns |   0.034 ns |   0.030 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |      49.48 ns |   0.077 ns |   0.072 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     355.23 ns |   3.838 ns |   3.205 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     585.84 ns |   0.854 ns |   0.713 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      38.41 ns |   0.147 ns |   0.137 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |      81.48 ns |   0.385 ns |   0.360 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     428.13 ns |   0.831 ns |   0.777 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     541.51 ns |   1.565 ns |   1.387 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      88.06 ns |   0.104 ns |   0.092 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |      96.02 ns |   0.187 ns |   0.166 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,463.65 ns |   5.846 ns |   5.468 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,256.64 ns |   3.952 ns |   3.696 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     347.12 ns |   0.197 ns |   0.174 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     422.21 ns |   0.439 ns |   0.411 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,072.51 ns |   3.323 ns |   3.108 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,207.96 ns |   2.113 ns |   1.977 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     440.94 ns |   0.864 ns |   0.808 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     592.10 ns |   1.382 ns |   1.292 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  18,748.41 ns |  55.514 ns |  49.211 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,411.00 ns |  23.821 ns |  19.891 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,157.82 ns |   4.426 ns |   3.696 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,177.84 ns |   2.617 ns |   2.448 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,187.32 ns |  29.494 ns |  27.588 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,557.34 ns |  23.812 ns |  22.273 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,501.55 ns |  10.938 ns |  10.232 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |   9,187.51 ns |  13.535 ns |  12.661 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 300,629.19 ns | 307.989 ns | 273.025 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 389,408.52 ns | 358.985 ns | 335.795 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  51,196.60 ns |  55.046 ns |  48.797 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  51,488.02 ns |  98.674 ns |  92.300 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 386,002.16 ns | 378.129 ns | 353.702 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 392,598.37 ns | 430.614 ns | 402.796 ns |     832 B |