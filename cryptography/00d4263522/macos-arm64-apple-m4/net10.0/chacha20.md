| Description                             | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     174.7 ns |      2.91 ns |      2.72 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     245.8 ns |      1.43 ns |      1.12 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     529.7 ns |      7.95 ns |      7.05 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     732.6 ns |     12.42 ns |     11.62 ns |         - |
|                                         |              |              |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     174.6 ns |      3.49 ns |      3.58 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     246.2 ns |      1.80 ns |      1.40 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     525.3 ns |      4.40 ns |      3.44 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     732.2 ns |     11.55 ns |     10.81 ns |         - |
|                                         |              |              |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,362.2 ns |     23.11 ns |     21.61 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,883.9 ns |     27.97 ns |     26.16 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,979.7 ns |     37.51 ns |     35.08 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   5,814.9 ns |    114.34 ns |    117.41 ns |         - |
|                                         |              |              |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,361.1 ns |     18.15 ns |     16.98 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,886.7 ns |     27.23 ns |     25.47 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,980.3 ns |     38.85 ns |     36.34 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   5,784.3 ns |    103.82 ns |     97.12 ns |         - |
|                                         |              |              |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,863.1 ns |    196.03 ns |    183.37 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,502.5 ns |    281.27 ns |    263.10 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,622.2 ns |    306.34 ns |    286.55 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  46,243.2 ns |    779.87 ns |    729.49 ns |         - |
|                                         |              |              |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,853.3 ns |    182.01 ns |    170.25 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,946.9 ns |    268.57 ns |    251.22 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,542.3 ns |    342.37 ns |    320.25 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  46,247.0 ns |    800.92 ns |    749.18 ns |         - |
|                                         |              |              |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 173,799.6 ns |  2,585.94 ns |  2,418.89 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 238,997.3 ns |  3,438.81 ns |  3,216.67 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 359,479.3 ns |  6,149.54 ns |  5,752.28 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 740,170.7 ns | 11,925.03 ns | 11,154.68 ns |         - |
|                                         |              |              |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 173,418.9 ns |  2,972.55 ns |  2,635.08 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 238,726.7 ns |  3,314.12 ns |  3,100.03 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 358,935.8 ns |  3,973.19 ns |  3,716.53 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 741,792.8 ns | 13,687.24 ns | 12,803.05 ns |         - |