| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1,058.6 ns |     21.18 ns |     38.73 ns |     1,038.2 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,452.2 ns |     44.16 ns |     66.10 ns |     2,423.7 ns |    1208 B |
|                                             |              |                |              |              |                |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |       934.4 ns |      0.26 ns |      0.20 ns |       934.5 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2,202.9 ns |     43.58 ns |     63.88 ns |     2,213.7 ns |    1208 B |
|                                             |              |                |              |              |                |           |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    13,360.5 ns |      8.81 ns |      8.24 ns |    13,359.2 ns |    3448 B |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    18,050.8 ns |  4,418.76 ns | 13,028.82 ns |     7,848.6 ns |         - |
|                                             |              |                |              |              |                |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |     6,986.3 ns |    251.39 ns |    644.40 ns |     6,675.0 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    12,960.8 ns |      6.54 ns |      5.80 ns |    12,959.5 ns |    3448 B |
|                                             |              |                |              |              |                |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,016.6 ns |     44.07 ns |     39.06 ns |    52,002.3 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   102,824.8 ns |    101.97 ns |     95.38 ns |   102,839.6 ns |   21368 B |
|                                             |              |                |              |              |                |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    52,276.7 ns |     13.81 ns |     12.92 ns |    52,276.0 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |    99,973.3 ns |     42.99 ns |     38.11 ns |    99,976.2 ns |   21368 B |
|                                             |              |                |              |              |                |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   831,444.3 ns |    274.06 ns |    242.95 ns |   831,416.3 ns |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,642,031.9 ns |    659.79 ns |    550.96 ns | 1,641,857.6 ns |  328568 B |
|                                             |              |                |              |              |                |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        |   835,533.3 ns |  1,580.33 ns |  1,233.82 ns |   835,215.9 ns |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,720,029.7 ns | 18,705.36 ns | 17,497.00 ns | 1,717,141.5 ns |  328568 B |