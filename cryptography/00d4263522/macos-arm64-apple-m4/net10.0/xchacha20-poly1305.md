| Description                                       | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     907.4 ns |     10.46 ns |      9.78 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,503.3 ns |     17.57 ns |     16.43 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,821.5 ns |     23.90 ns |     22.35 ns |         - |
|                                                   |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     757.1 ns |     13.48 ns |     12.61 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,468.2 ns |     21.21 ns |     19.84 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,751.7 ns |     24.38 ns |     22.80 ns |         - |
|                                                   |              |              |              |              |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,531.5 ns |     12.49 ns |      9.75 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,713.7 ns |     81.64 ns |     76.37 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,527.0 ns |     96.01 ns |     89.81 ns |         - |
|                                                   |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,421.7 ns |     44.36 ns |     41.49 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,667.8 ns |     79.60 ns |     74.46 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,414.7 ns |     45.19 ns |     35.28 ns |         - |
|                                                   |              |              |              |              |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  15,232.0 ns |    184.96 ns |    173.01 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  48,230.9 ns |    546.29 ns |    511.00 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  51,570.7 ns |    792.75 ns |    741.54 ns |         - |
|                                                   |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,993.1 ns |     97.94 ns |     76.47 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  48,182.0 ns |    585.22 ns |    547.41 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  51,553.8 ns |    807.24 ns |    755.09 ns |         - |
|                                                   |              |              |              |              |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 233,655.4 ns |  3,440.65 ns |  3,218.39 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 759,632.0 ns |  9,346.80 ns |  8,743.00 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 808,483.5 ns | 11,989.03 ns | 11,214.54 ns |         - |
|                                                   |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 234,188.0 ns |  3,187.05 ns |  2,981.17 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 761,214.6 ns |  9,576.84 ns |  8,958.18 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 807,988.4 ns | 12,835.90 ns | 12,006.71 ns |         - |