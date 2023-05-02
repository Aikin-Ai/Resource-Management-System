// import '@/styles/globals.css'
import { Analytics } from '@vercel/analytics/react'
import './index.css'

export default function App({ Component, pageProps }) {
  return (
    <>
      <Component {...pageProps} />
      <Analytics />
    </>
  )
}