| Description                             | TestDataSize | Mean           | Error       | StdDev      | Median         | Allocated |
|---------------------------------------- |------------- |---------------:|------------:|------------:|---------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |       885.6 ns |     0.98 ns |     0.91 ns |       885.4 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     1,472.0 ns |    28.32 ns |    26.49 ns |     1,478.2 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     2,712.0 ns |     1.87 ns |     1.56 ns |     2,711.6 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     3,487.6 ns |     1.19 ns |     0.99 ns |     3,487.3 ns |         - |
|                                         |              |                |             |             |                |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |       885.6 ns |     0.56 ns |     0.52 ns |       885.5 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     1,465.2 ns |    20.58 ns |    17.19 ns |     1,467.5 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     2,713.6 ns |     3.25 ns |     3.04 ns |     2,712.2 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     3,479.6 ns |     1.46 ns |     1.29 ns |     3,479.4 ns |         - |
|                                         |              |                |             |             |                |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |     6,969.0 ns |     6.62 ns |     5.87 ns |     6,967.8 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |     8,688.3 ns |   173.89 ns |   374.31 ns |     8,979.5 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |    15,278.2 ns |     1.60 ns |     1.25 ns |    15,277.8 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    27,515.6 ns |    23.72 ns |    19.81 ns |    27,508.5 ns |         - |
|                                         |              |                |             |             |                |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |     6,971.7 ns |     5.91 ns |     5.24 ns |     6,972.1 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |     8,747.7 ns |   174.74 ns |   352.98 ns |     8,948.1 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |    15,280.2 ns |     3.34 ns |     2.96 ns |    15,279.7 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    27,505.9 ns |    11.81 ns |    10.47 ns |    27,502.4 ns |         - |
|                                         |              |                |             |             |                |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |    55,596.4 ns |    57.71 ns |    48.19 ns |    55,597.1 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |    63,145.6 ns |    25.00 ns |    22.17 ns |    63,150.0 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |   116,123.6 ns |    68.27 ns |    57.01 ns |   116,113.7 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |   219,494.8 ns |    59.29 ns |    52.56 ns |   219,487.6 ns |         - |
|                                         |              |                |             |             |                |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |    55,590.6 ns |    33.51 ns |    27.99 ns |    55,579.6 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |    64,638.2 ns | 1,286.61 ns | 1,885.90 ns |    63,799.6 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |   116,157.5 ns |    32.48 ns |    28.79 ns |   116,150.5 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |   219,433.8 ns |    97.01 ns |    81.01 ns |   219,461.3 ns |         - |
|                                         |              |                |             |             |                |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        |   888,142.6 ns |   290.36 ns |   226.69 ns |   888,114.3 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 1,007,533.6 ns | 2,335.69 ns | 2,184.80 ns | 1,008,171.6 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 1,836,344.0 ns |   880.80 ns |   735.51 ns | 1,836,603.8 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 3,512,558.6 ns | 2,277.03 ns | 2,129.93 ns | 3,511,660.2 ns |         - |
|                                         |              |                |             |             |                |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        |   888,519.1 ns |   795.00 ns |   743.64 ns |   888,202.7 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 1,007,309.4 ns | 1,247.26 ns | 1,166.69 ns | 1,007,598.7 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 1,839,740.1 ns |   625.78 ns |   522.56 ns | 1,839,583.2 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 3,511,311.3 ns | 1,720.62 ns | 1,525.28 ns | 3,510,710.0 ns |         - |