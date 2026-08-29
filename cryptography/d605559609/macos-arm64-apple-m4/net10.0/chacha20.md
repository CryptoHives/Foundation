| Description                             | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     178.9 ns |     0.79 ns |     0.70 ns |     178.8 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     244.6 ns |     1.66 ns |     1.56 ns |     244.3 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     551.8 ns |     2.81 ns |     2.63 ns |     550.7 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     844.0 ns |     0.29 ns |     0.24 ns |     844.0 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     175.8 ns |     0.46 ns |     0.43 ns |     175.8 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     246.6 ns |     1.36 ns |     1.27 ns |     246.7 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     543.7 ns |     2.57 ns |     2.40 ns |     543.8 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     843.8 ns |     0.34 ns |     0.32 ns |     843.7 ns |         - |
|                                         |              |              |             |             |              |           |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,842.0 ns |     1.28 ns |     1.20 ns |   1,841.7 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,954.1 ns |    14.45 ns |    13.52 ns |   2,951.6 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   3,026.7 ns |   900.45 ns | 2,655.00 ns |   1,337.9 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,470.3 ns |    28.34 ns |    26.51 ns |   6,474.4 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,395.1 ns |     5.19 ns |     4.85 ns |   1,395.8 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,962.3 ns |    38.94 ns |    72.18 ns |   1,990.8 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   6,624.0 ns | 1,889.69 ns | 5,571.80 ns |   2,988.2 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,653.1 ns |     1.32 ns |     1.11 ns |   6,653.3 ns |         - |
|                                         |              |              |             |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,790.8 ns |    59.38 ns |    55.55 ns |  10,794.4 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,113.4 ns |     3.43 ns |     2.86 ns |  14,113.6 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,961.8 ns |   114.37 ns |   106.98 ns |  22,968.2 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  53,110.3 ns |    31.17 ns |    27.63 ns |  53,114.7 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,673.7 ns |     2.10 ns |     1.86 ns |  10,673.3 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,109.7 ns |     3.19 ns |     2.98 ns |  14,109.8 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,355.9 ns |   122.22 ns |   114.32 ns |  22,350.8 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  52,227.8 ns |   160.96 ns |   150.57 ns |  52,226.1 ns |         - |
|                                         |              |              |             |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 178,194.6 ns | 1,184.39 ns | 1,107.88 ns | 177,637.4 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 235,498.4 ns |    33.53 ns |    29.73 ns | 235,498.1 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 373,265.7 ns | 1,320.91 ns | 1,235.58 ns | 373,191.3 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 851,944.6 ns |   141.16 ns |   125.13 ns | 851,919.2 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 174,016.6 ns |   925.84 ns |   866.03 ns | 173,940.2 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 235,354.3 ns |    52.51 ns |    43.85 ns | 235,349.8 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 366,191.0 ns | 1,666.18 ns | 1,558.55 ns | 365,788.9 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 851,094.5 ns |   383.07 ns |   339.58 ns | 851,086.3 ns |         - |