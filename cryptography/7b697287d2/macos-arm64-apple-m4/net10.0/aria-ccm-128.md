| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     2.038 μs | 0.0013 μs | 0.0012 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     4.717 μs | 0.0175 μs | 0.0155 μs |    3448 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     1.987 μs | 0.0010 μs | 0.0009 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     4.673 μs | 0.0173 μs | 0.0162 μs |    3336 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    12.936 μs | 0.0067 μs | 0.0056 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    26.643 μs | 0.0641 μs | 0.0599 μs |    8824 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    12.891 μs | 0.0035 μs | 0.0033 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    26.688 μs | 0.0605 μs | 0.0566 μs |    7816 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   100.154 μs | 0.0489 μs | 0.0434 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   200.390 μs | 0.5247 μs | 0.4908 μs |   51832 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   100.051 μs | 0.0346 μs | 0.0307 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   202.981 μs | 0.4697 μs | 0.4394 μs |   43656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 1,595.957 μs | 0.6872 μs | 0.5365 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 3,279.599 μs | 6.1790 μs | 5.7799 μs |  789138 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 1,598.002 μs | 0.7775 μs | 0.7273 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 3,213.684 μs | 6.8030 μs | 6.0307 μs |  658056 B |