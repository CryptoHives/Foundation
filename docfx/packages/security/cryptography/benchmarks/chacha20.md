| Description                       | TestDataSize | Mean           | Error         | StdDev       | Median         | Allocated |
|---------------------------------- |------------- |---------------:|--------------:|-------------:|---------------:|----------:|
| Decrypt · ChaCha20 (Managed)      | 128B         |       415.3 ns |      58.52 ns |     170.7 ns |       350.0 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     4,065.6 ns |     238.83 ns |     677.5 ns |     4,000.0 ns |     552 B |
|                                   |              |                |               |              |                |           |
| Encrypt · ChaCha20 (Managed)      | 128B         |       485.0 ns |      60.86 ns |     179.4 ns |       500.0 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     4,114.4 ns |     243.73 ns |     707.1 ns |     4,000.0 ns |     552 B |
|                                   |              |                |               |              |                |           |
| Decrypt · ChaCha20 (Managed)      | 1KB          |     1,360.2 ns |      87.47 ns |     255.1 ns |     1,300.0 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |    19,550.0 ns |     383.67 ns |     410.5 ns |    19,600.0 ns |    2344 B |
|                                   |              |                |               |              |                |           |
| Encrypt · ChaCha20 (Managed)      | 1KB          |     1,383.5 ns |      80.02 ns |     232.1 ns |     1,400.0 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |    19,933.0 ns |     820.39 ns |   2,380.1 ns |    18,700.0 ns |    2344 B |
|                                   |              |                |               |              |                |           |
| Decrypt · ChaCha20 (Managed)      | 8KB          |     8,590.0 ns |     310.11 ns |     914.4 ns |     8,100.0 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |   120,210.0 ns |   4,624.99 ns |  13,636.9 ns |   115,100.0 ns |   16680 B |
|                                   |              |                |               |              |                |           |
| Encrypt · ChaCha20 (Managed)      | 8KB          |     8,104.5 ns |     153.84 ns |     188.9 ns |     8,100.0 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |   115,999.0 ns |   4,582.17 ns |  13,366.4 ns |   109,700.0 ns |   16680 B |
|                                   |              |                |               |              |                |           |
| Decrypt · ChaCha20 (Managed)      | 128KB        |   140,552.5 ns |   5,275.97 ns |  15,473.5 ns |   130,000.0 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 1,211,142.0 ns | 238,169.00 ns | 702,246.7 ns | 1,499,950.0 ns |  262440 B |
|                                   |              |                |               |              |                |           |
| Encrypt · ChaCha20 (Managed)      | 128KB        |   141,177.0 ns |   5,325.02 ns |  15,700.9 ns |   141,000.0 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 1,254,636.0 ns | 246,748.61 ns | 727,543.9 ns | 1,508,750.0 ns |  262440 B |